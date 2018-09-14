using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EventFlow.Aggregates;
using EventFlow.Queries;
using EventFlow.Sagas;
using EventFlow.Sagas.AggregateSagas;
using Simulator.Domain.Consultation;
using Simulator.Domain.Consultation.Commands;
using Simulator.Domain.ConsultationScheduler.Events;
using Simulator.Domain.ConsultationScheduler.Services;
using Simulator.Domain.Doctor;
using Simulator.Domain.Doctor.Commands;
using Simulator.Domain.Doctor.Events;
using Simulator.Domain.Patient;
using Simulator.Domain.Patient.Events;
using Simulator.Domain.Treatmentroom;
using Simulator.Domain.Treatmentroom.Commands;
using Simulator.Domain.Treatmentroom.Events;
using Simulator.Query.Doctor;
using Simulator.Query.TreatmentMachine;
using Simulator.Query.TreatmentRoom;

namespace Simulator.Domain.ConsultationScheduler
{
    public sealed class ConsultationSchedulerSaga : AggregateSaga<ConsultationSchedulerSaga, ConsultationSchedulerSagaId,ConsultationSchedulerSagaLocator>,
        ISagaIsStartedBy<PatientAggregate,PatientId,CancerPatientWithHeadAndNeckTopygraphyIsRegistered>,
        ISagaIsStartedBy<PatientAggregate,PatientId, CancerPatientWithBreastTopygraphyIsRegistered>,
        ISagaIsStartedBy<PatientAggregate,PatientId, FluPatientIsRegistered>,
        ISagaHandles<TreatmentRoomAggregate,TreatmentRoomId,TreatmentRoomIsReservedEvent>,
        ISagaHandles<TreatmentRoomAggregate,TreatmentRoomId,TreatmentRoomReservationIsRejectedEvent>,
        ISagaHandles<DoctorAggregate,DoctorId,Doctor.Events.DoctorIsReservedEvent>,
        ISagaHandles<DoctorAggregate,DoctorId,DoctorReservationIsRejectedEvent>
    {

        private readonly IQueryProcessor _queryProcessor;
        private readonly IConsultationSchedulerService _consultationSchedulerService;
        private readonly ConsultationSchedulerState _state = new ConsultationSchedulerState();

        public ConsultationSchedulerSaga(ConsultationSchedulerSagaId schedulerSagaId, IQueryProcessor queryProcessor, IConsultationSchedulerService consultationSchedulerService) : base(schedulerSagaId)
        {
            _queryProcessor = queryProcessor;
            _consultationSchedulerService = consultationSchedulerService;
            Register(_state);
        }

        public async Task HandleAsync(
            IDomainEvent<PatientAggregate, PatientId, CancerPatientWithHeadAndNeckTopygraphyIsRegistered> @event,
            ISagaContext sagaContext, CancellationToken cancellationToken)
        {
            this.Emit(new ConsultationSchedulingIsStartedEvent(@event.AggregateIdentity,
                @event.AggregateEvent.RegistrationDate));

            var doctors = await _queryProcessor.ProcessAsync(DoctorQueriesFactory.GetAllOncologists, cancellationToken).ConfigureAwait(false);

            var machines = await _queryProcessor.ProcessAsync(TreatmentMachineQueriesFactory.GetWithAdvanceCapability, cancellationToken).ConfigureAwait(false);
            var machineIds = machines.Select(x => x.Id);
            var rooms = await _queryProcessor.ProcessAsync(TreatmentRoomQueriesFactory.RoomsEquippedWithAnyOfTheseMachines(machineIds), cancellationToken).ConfigureAwait(false);

            await HandleReservation(rooms, doctors).ConfigureAwait(false);
        }

        public async Task HandleAsync(IDomainEvent<PatientAggregate, PatientId, CancerPatientWithBreastTopygraphyIsRegistered> @event, ISagaContext sagaContext, CancellationToken cancellationToken)
        {
            this.Emit(new ConsultationSchedulingIsStartedEvent(@event.AggregateIdentity,
                @event.AggregateEvent.RegistrationDate));

            var doctors = await _queryProcessor.ProcessAsync(DoctorQueriesFactory.GetAllOncologists, cancellationToken).ConfigureAwait(false);

            var machines = await _queryProcessor.ProcessAsync(TreatmentMachineQueriesFactory.GetRoomsWithAdvanceOrSimpleCapability, cancellationToken).ConfigureAwait(false);
            var machineIds = machines.Select(x => x.Id);

            var rooms = await _queryProcessor.ProcessAsync(TreatmentRoomQueriesFactory.RoomsEquippedWithAnyOfTheseMachines(machineIds), cancellationToken).ConfigureAwait(false);

            await HandleReservation(rooms, doctors).ConfigureAwait(false);
        }

        public async Task HandleAsync(IDomainEvent<PatientAggregate, PatientId, FluPatientIsRegistered> @event, ISagaContext sagaContext, CancellationToken cancellationToken)
        {
            this.Emit(new ConsultationSchedulingIsStartedEvent(@event.AggregateIdentity,
                @event.AggregateEvent.RegistrationDate));

            var doctors = await _queryProcessor.ProcessAsync(DoctorQueriesFactory.GetAllGeneralPractitioners, cancellationToken).ConfigureAwait(false);

            var rooms = await _queryProcessor.ProcessAsync(TreatmentRoomQueriesFactory.GetAllTreatmentRooms, cancellationToken).ConfigureAwait(false);

            await HandleReservation(rooms, doctors).ConfigureAwait(false);
        }

        private async Task HandleReservation(IReadOnlyCollection<TreatmentRoomReadModel> treatmentRooms, IReadOnlyCollection<DoctorReadModel> doctors)
        {
            //Any treatment room is fine for flu patient
            var reservationRquest = _consultationSchedulerService.GetReservationRequest(treatmentRooms, doctors);
            InitiateReservation(reservationRquest.Item1, reservationRquest.Item2, reservationRquest.Item3);
        }

        //TODO:Instead of a tuple, return a value object


        private void InitiateReservation(DateTime firstAvailableDay, TreatmentRoomId treatmentRoomId, DoctorId doctorId)
        {
            this.PublishReserveTreatmentroomCommand(treatmentRoomId, firstAvailableDay);
            this.PublishBookDoctorCommand(doctorId, firstAvailableDay);
        }

        private void PublishCreateConsultationCommand()
        {
            var id = ConsultationId.New;
            var command = new CreateConsultationCommand(id, _state.PatientId, _state.DoctorId, _state.TreatmentRoomId,
                _state.PatientRegistrationDate, _state.ConsultationDate.Value);
            this.Publish(command);
        }

        private void PublishBookDoctorCommand(DoctorId doctorId, DateTime reservationDay)
        {
            var command = new ReserveDoctorCommand(doctorId, reservationDay,Id.Value);
            this.Publish(command);
        }

        private void PublishReserveTreatmentroomCommand(TreatmentRoomId treatmentRoomId, DateTime reservationDay)
        {
            var command = new ReserveTreatmentRoomCommand(treatmentRoomId,reservationDay, Id.Value);
            this.Publish(command);
        }


        public async Task HandleAsync(IDomainEvent<TreatmentRoomAggregate, TreatmentRoomId, TreatmentRoomIsReservedEvent> @event, ISagaContext sagaContext, CancellationToken cancellationToken)
        {
            this.Emit(new SchedulerHasReservedTreatmentRoom(@event.AggregateIdentity,@event.AggregateEvent.ReservationDay));

            WhenSchedulingIsCompledCreateConsultation();
        }

        private void WhenSchedulingIsCompledCreateConsultation()
        {
            if (_state.IsSchedulingCompleted)
            {
                this.PublishCreateConsultationCommand();
                Complete();
            }
        }

        public async Task HandleAsync(IDomainEvent<DoctorAggregate, DoctorId, DoctorIsReservedEvent> @event, ISagaContext sagaContext, CancellationToken cancellationToken)
        {
            this.Emit(new SchedulerHasReservedDoctorEvent(@event.AggregateIdentity, @event.AggregateEvent.ReservationDay));

            WhenSchedulingIsCompledCreateConsultation();
        }

        public async Task HandleAsync(IDomainEvent<TreatmentRoomAggregate, TreatmentRoomId, TreatmentRoomReservationIsRejectedEvent> @event, ISagaContext sagaContext, CancellationToken cancellationToken)
        {
            //TODO: Issue rectification command to rollback, a doctor's to booking if any doctor is already booked with this sagaId
        }

        public async Task HandleAsync(IDomainEvent<DoctorAggregate, DoctorId, DoctorReservationIsRejectedEvent> @event, ISagaContext sagaContext, CancellationToken cancellationToken)
        {
            //TODO: Issue rectification command to rollback, a room's to booking if any room is already booked with this sagaId
        }
    }
}