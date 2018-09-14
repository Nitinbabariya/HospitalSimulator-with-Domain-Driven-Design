using System;

using EventFlow.Aggregates;
using EventFlow.ReadStores;
using Simulator.Domain.Consultation;
using Simulator.Domain.Consultation.Events;
using Simulator.Domain.Doctor;
using Simulator.Domain.Patient;
using Simulator.Domain.Treatmentroom;

namespace Simulator.Query.Consultation
{
    public sealed class ConsultationReadModel : IReadModel, IAmReadModelFor<ConsultationAggregate, ConsultationId, ConsultationIsCreatedEvent>
    {
        public ConsultationId ConsultationId { get; private set; }
        public PatientId PatientId { get; private set; }
        public DoctorId DoctorId { get; private set; }
        public TreatmentRoomId TreatmentRoomId { get; private set; }
        public DateTime RegistrationDate { get; private set; }
        public DateTime ConsultationDate { get; private set; }
        public DateTime Timestamp { get; private set; }

        public void Apply(IReadModelContext context, IDomainEvent<ConsultationAggregate, ConsultationId, ConsultationIsCreatedEvent> domainEvent)
        {
            ConsultationId =domainEvent.AggregateEvent.ConsultationId;
            PatientId =domainEvent.AggregateEvent.PatientId;
            DoctorId = domainEvent.AggregateEvent.DoctorId;
            TreatmentRoomId = domainEvent.AggregateEvent.TreatmentRoomId;
            RegistrationDate = domainEvent.AggregateEvent.RegistrationDate;
            ConsultationDate = domainEvent.AggregateEvent.ConsultationDate;
            Timestamp = domainEvent.AggregateEvent.Timestamp;
        }
    }
}