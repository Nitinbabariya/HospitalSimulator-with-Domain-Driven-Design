using System;
using EventFlow.Aggregates;
using EventFlow.ReadStores;
using Simulator.Domain.Patient;
using Simulator.Domain.Patient.Events;

namespace Simulator.Query.Patient
{
    public sealed class PatientReadModel : IReadModel,
        IAmReadModelFor<PatientAggregate, PatientId, FluPatientIsRegistered>,
        IAmReadModelFor<PatientAggregate, PatientId, CancerPatientWithHeadAndNeckTopygraphyIsRegistered>,
        IAmReadModelFor<PatientAggregate, PatientId, CancerPatientWithBreastTopygraphyIsRegistered>
    {
        public string Id { get; private set; }
        public string Name { get; private set; }
        public DateTime RegistrationDate { get; private set; }

        public bool IsFluPatient { get; private set; }
        public bool IsCancerPatientWithHeadAndNeckTopography { get; private set; }
        public bool IsCancerPatientWitBreastTopography { get; private set; }

        public void Apply(IReadModelContext context, IDomainEvent<PatientAggregate, PatientId, FluPatientIsRegistered> domainEvent)
        {
            Id = domainEvent.AggregateIdentity.Value;
            Name = domainEvent.AggregateEvent.Name;
            RegistrationDate = domainEvent.AggregateEvent.RegistrationDate;
            IsFluPatient = true;
        }

        public void Apply(IReadModelContext context, IDomainEvent<PatientAggregate, PatientId, CancerPatientWithHeadAndNeckTopygraphyIsRegistered> domainEvent)
        {
            Id = domainEvent.AggregateIdentity.Value;
            Name = domainEvent.AggregateEvent.Name;
            RegistrationDate = domainEvent.AggregateEvent.RegistrationDate;
            IsCancerPatientWithHeadAndNeckTopography = true;
        }

        public void Apply(IReadModelContext context, IDomainEvent<PatientAggregate, PatientId, CancerPatientWithBreastTopygraphyIsRegistered> domainEvent)
        {
            Id = domainEvent.AggregateIdentity.Value;
            Name = domainEvent.AggregateEvent.Name;
            RegistrationDate = domainEvent.AggregateEvent.RegistrationDate;
            IsCancerPatientWitBreastTopography = true;
        }
    }
}