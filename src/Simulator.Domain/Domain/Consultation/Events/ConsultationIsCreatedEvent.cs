using System;
using System.Collections.Generic;
using EventFlow.Aggregates;
using EventFlow.EventStores;
using Simulator.Domain.Common;
using Simulator.Domain.Doctor;
using Simulator.Domain.Patient;
using Simulator.Domain.Treatmentroom;

namespace Simulator.Domain.Consultation.Events
{
    [EventVersion("ConsultationIsCreatedEvent", 1)]

    public sealed class ConsultationIsCreatedEvent : AggregateEvent<ConsultationAggregate, ConsultationId>
    {
        public readonly ConsultationId ConsultationId;
        public readonly PatientId PatientId;
        public readonly DoctorId DoctorId;
        public readonly TreatmentRoomId TreatmentRoomId;
        public readonly DateTime RegistrationDate;
        public readonly DateTime ConsultationDate;
        public readonly DateTime Timestamp;

        public ConsultationIsCreatedEvent(ConsultationId consultationId, PatientId patientId, DoctorId doctorId, TreatmentRoomId treatmentRoomId, DateTime registrationDate, DateTime consultationDate)
        {
            ConsultationId = consultationId;
            PatientId = patientId;
            DoctorId = doctorId;
            TreatmentRoomId = treatmentRoomId;
            RegistrationDate = registrationDate;
            ConsultationDate = consultationDate;
            Timestamp = DateTime.UtcNow;
        }
    }
}