using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Threading;
using System.Threading.Tasks;

using Autofac;

using EventFlow;
using EventFlow.Commands;
using EventFlow.Queries;
using EventFlow.ReadStores;

using Simulator.Application.Client;
using Simulator.Application.Client.Doctor;
using Simulator.Domain.Doctor;
using Simulator.Domain.Doctor.Commands;
using Simulator.Domain.Patient;
using Simulator.Domain.Patient.Commands;
using Simulator.Domain.TreatmentMachine;
using Simulator.Domain.TreatmentMachine.Commands;
using Simulator.Domain.Treatmentroom;
using Simulator.Domain.Treatmentroom.Commands;
using Simulator.Query.Consultation;
using Simulator.Query.Doctor;
using Simulator.Query.Patient;
using Simulator.Query.TreatmentMachine;
using Simulator.Query.TreatmentRoom;

using Role = Simulator.Application.Client.Doctor.Role;

namespace Simulator.Application
{
    public sealed class SimulatorClient:IDisposable
    {
        private readonly IQueryProcessor _queryProcessor;
        private readonly ICommandBus _commandBus;
        private readonly ILifetimeScope container;
        private readonly IReadModelPopulator populator;

        public SimulatorClient(IQueryProcessor queryProcessor, ICommandBus commandBus, ILifetimeScope container, IReadModelPopulator populator)
        {
            _queryProcessor = queryProcessor;
            _commandBus = commandBus;
            this.container = container;
            this.populator = populator;
        }

        public void Dispose()
        {
            this.container.Dispose();
        }

        public void Publish(params ICommand[] commands)
        {
            try
            {
                foreach (var command in commands)
                {
                    command.PublishAsync(_commandBus, CancellationToken.None).Wait();
                }
            }
            catch (AggregateException e)
            {
                ExceptionDispatchInfo.Capture(e.InnerException).Throw();
            }
        }



        [DebuggerStepThrough]
        public TResult Query<TResult>(IQuery<TResult> query)
        {
            try
            {
                return this._queryProcessor.ProcessAsync(query, CancellationToken.None).Result;
            }
            catch (AggregateException e)
            {
                ExceptionDispatchInfo.Capture(e.InnerException).Throw();
                throw;
            }
        }

        public DoctorModel AddDoctor(string name, params Role[] roles)
        {
            var doctorId = DoctorId.New;
            var domainRoles = roles.ToDomain();
            var command = new AddDoctorCommand(doctorId, name, domainRoles);
            this.Publish(command);
            return new DoctorModel(command.AggregateId, this);
        }


        public IReadOnlyCollection<DoctorModel> GetDoctorsById(string doctorId)
        {
            var entities = this.Query(DoctorQueriesFactory.GetById(doctorId));
            return entities.Select(e => new DoctorModel(e, this)).ToList().AsReadOnly();
        }

        public PatientModel RegisterCancerPatientWithHeadAndNeckTopography(string name)
        {
            var patientId= PatientId.New;
            var command = new RegisterCancerPatientWithHeadAndNeckTopographyCommand(patientId, name);
            this.Publish(command);
            return new PatientModel(command.AggregateId, this);
        }

        public PatientModel RegisterCancerPatientWithBreastTopography(string name)
        {
            var patientId = PatientId.New;
            var command = new RegisterCancerPatientWithBreastTopographyCommand(patientId, name);
            this.Publish(command);
            return new PatientModel(command.AggregateId, this);
        }

        public PatientModel RegisterFluPatient(string name)
        {
            var patientId = PatientId.New;
            var command = new RegisterFluPatientCommand(patientId, name);
            this.Publish(command);
            return new PatientModel(command.AggregateId, this);
        }


        public IEnumerable<TreatmentMachineModel> GetAllTreatmentMachines()
        {
            var entities = this.Query(TreatmentMachineQueriesFactory.GetAllMachines);
            return entities.Select(e => new TreatmentMachineModel(e, this)).ToList().AsReadOnly();
        }

        public TreatmentMachineModel AddMachineWithSimpleCapability(string name)
        {
            var machineId = TreatmentMachineId.New;
            var command = new AddTreatmentMachineWithSimpleCapabilityCommand(machineId, name);
            this.Publish(command);
            return new TreatmentMachineModel(command.AggregateId,this);
        }

        public TreatmentMachineModel AddMachineWithAdvancedCapability(string name)
        {
            var machineId = TreatmentMachineId.New;
            var command = new AddTreatmentMachineWithAdvanceCapabilityCommand(machineId, name);
            this.Publish(command);
            return new TreatmentMachineModel(command.AggregateId, this);
        }


        public IEnumerable<TreatmentRoomModel> GetAllTreatmentRooms()
        {
            var entities = this.Query(TreatmentRoomQueriesFactory.GetAllTreatmentRooms);
            return entities.Select(e => new TreatmentRoomModel(e, this)).ToList().AsReadOnly();
        }

        public TreatmentRoomModel GetTreatmentRoomById(string treatmentRoomId)
        {
            var entities = this.Query(TreatmentRoomQueriesFactory.GetByTreatmentRoomId(treatmentRoomId));
            return new TreatmentRoomModel(entities.FirstOrDefault(), this);
        }

        public TreatmentRoomModel AddTreatmentRoom(string name)
        {
            var roomId = TreatmentRoomId.New;
            var command = new AddTreatmentRoomCommand(roomId, name);
            this.Publish(command);
            return new TreatmentRoomModel(command.AggregateId, this);
        }

        public TreatmentRoomModel AddTreatmentRoom(string name, string treatmentMachineName)
        {
            var treatmentRoomModel = AddTreatmentRoom(name);

            var treamentMachineModel = Query(TreatmentMachineQueriesFactory.GetMachineByName(treatmentMachineName));

            var treatmentMachineId = new TreatmentMachineId(treamentMachineModel.Id);

            var command = new EquipTreatmentRoomWithMachineCommand(treatmentRoomModel.Id, treatmentMachineId);
            this.Publish(command);
            return new TreatmentRoomModel(command.AggregateId, this);
        }

        public IEnumerable<PatientReadModel> GetRegisteredPatients() => this.Query(PatientQueriesFactory.GetAllRegisteredPatientsQuery);

        public IEnumerable<ConsultationReadModel> GetScheduledConsultations() => this.Query(ConsultationQueriesFactory.GetAllScheduledConsultationQuery);

        //TODO:Seed API by playing events instead of publishing the commands
        public void SeedWithHistoricalEvents()
        {
            this.AddDoctor("John", Role.Oncologist);
            this.AddDoctor("Anna", Role.GeneralPractitioner);
            this.AddDoctor("Laura", Role.GeneralPractitioner, Role.Oncologist);

            this.AddMachineWithAdvancedCapability("MachineA");
            this.AddMachineWithAdvancedCapability("MachineA");
            this.AddMachineWithAdvancedCapability("MachineB");
            this.AddMachineWithSimpleCapability("MachineC");

            this.AddTreatmentRoom("RoomOne");
            this.AddTreatmentRoom("RoomTwo");
            this.AddTreatmentRoom("RoomThree","MachineA");
            this.AddTreatmentRoom("RoomFour", "MachineB");
            this.AddTreatmentRoom("RoomFive", "MachineC");
        }
    }
}