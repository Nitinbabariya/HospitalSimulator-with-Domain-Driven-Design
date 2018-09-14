using System;
using EventFlow.Aggregates;
using Simulator.Domain.Patient;

namespace Simulator.Domain.ConsultationScheduler.Events
{
    public sealed class ConsultationSchedulingIsStartedEvent :  AggregateEvent<ConsultationSchedulerSaga, ConsultationSchedulerSagaId>
    {
        public PatientId PatientId { get; }
        public DateTime RegistrationDate { get; }

        public ConsultationSchedulingIsStartedEvent(PatientId patientId, DateTime registrationDate)
        {
            PatientId = patientId;
            RegistrationDate = registrationDate;
        }
    }
}