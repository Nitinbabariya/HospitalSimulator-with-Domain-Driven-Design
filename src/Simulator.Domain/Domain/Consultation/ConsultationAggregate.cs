using System;
using EventFlow.Aggregates;
using EventFlow.Extensions;

using Simulator.Domain.Consultation.Events;
using Simulator.Domain.Doctor;
using Simulator.Domain.Patient;
using Simulator.Domain.Treatmentroom;

namespace Simulator.Domain.Consultation
{
    public sealed class ConsultationAggregate:AggregateRoot<ConsultationAggregate, ConsultationId>
    {
        readonly ConsultationState _state = new ConsultationState();
        public ConsultationAggregate(ConsultationId id) : base(id)
        {
            Register(_state);
        }

        public void CreateConsultation(PatientId patientId, DoctorId doctorId, TreatmentRoomId treatmentRoomId, DateTime registrationDate, DateTime consultationDate)
        {
            Specs.AggregateIsNew.ThrowDomainErrorIfNotSatisfied(this);
            Emit(new ConsultationIsCreatedEvent(Id, patientId, doctorId, treatmentRoomId, registrationDate, consultationDate));
        }
    }
}