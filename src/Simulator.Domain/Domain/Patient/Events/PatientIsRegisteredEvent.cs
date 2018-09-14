using System;
using EventFlow.Aggregates;
using Simulator.Domain.Common;

namespace Simulator.Domain.Patient.Events
{
    public abstract class PatientIsRegisteredEvent : AggregateEvent<PatientAggregate, PatientId>
    {
        public PatientId Id { get; }
        public Name Name { get; }
        public DateTime RegistrationDate{ get; }

        protected PatientIsRegisteredEvent(PatientId patientId,Name name)
        {
            Id = patientId;
            Name = name;
            RegistrationDate = DateTime.UtcNow;
        }
    }
}