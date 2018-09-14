using System;

using EventFlow.Aggregates;
using Simulator.Domain.Consultation.Events;
using Simulator.Domain.Doctor;
using Simulator.Domain.Patient;
using Simulator.Domain.Treatmentroom;

namespace Simulator.Domain.Consultation
{
    internal sealed class ConsultationState : AggregateState<ConsultationAggregate, ConsultationId, ConsultationState>,
        IApply<ConsultationIsCreatedEvent>
    {
        public PatientId PatientId { get; private set; }
        public DoctorId DoctorId { get; private set; }
        public TreatmentRoomId TreatmentRoomId { get; private set; }
        public DateTime RegistrationDate { get; private set; }
        public DateTime ConsultationDate { get; private set; }

        public void Apply(ConsultationIsCreatedEvent aggregateEvent)
        {
            PatientId = aggregateEvent.PatientId;
            DoctorId = aggregateEvent.DoctorId;
            TreatmentRoomId = aggregateEvent.TreatmentRoomId;
            RegistrationDate = aggregateEvent.RegistrationDate;
            ConsultationDate = aggregateEvent.ConsultationDate;
        }
    }
}