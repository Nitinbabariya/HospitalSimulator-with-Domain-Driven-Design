using EventFlow.Aggregates;
using EventFlow.Extensions;
using Simulator.Domain.Patient.Events;

namespace Simulator.Domain.Patient
{
    public sealed class PatientAggregate:AggregateRoot<PatientAggregate,PatientId>
    {
        readonly PatientState _state = new PatientState();
        public PatientAggregate(PatientId id) : base(id)
        {
            Register(_state);
        }

        public void RegisterCancerPatientWithHeadAndNeckTopography(string name)
        {
            Specs.AggregateIsNew.ThrowDomainErrorIfNotSatisfied(this);
            Emit(new CancerPatientWithHeadAndNeckTopygraphyIsRegistered(Id, name));
        }

        public void RegisterCancerPatientWithBreastTopography(string name)
        {
            Specs.AggregateIsNew.ThrowDomainErrorIfNotSatisfied(this);
            Emit(new CancerPatientWithBreastTopygraphyIsRegistered(Id, name));
        }

        public void RegisterFluPatient(string name)
        {
            Specs.AggregateIsNew.ThrowDomainErrorIfNotSatisfied(this);
            Emit(new FluPatientIsRegistered(Id, name));
        }
    }
}