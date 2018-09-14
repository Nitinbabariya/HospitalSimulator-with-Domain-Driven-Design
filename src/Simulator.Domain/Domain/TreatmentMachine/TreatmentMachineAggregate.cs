using EventFlow.Aggregates;
using EventFlow.Extensions;
using Simulator.Domain.Common;
using Simulator.Domain.TreatmentMachine.Events;

namespace Simulator.Domain.TreatmentMachine
{
    public sealed class TreatmentMachineAggregate : AggregateRoot<TreatmentMachineAggregate, TreatmentMachineId>
    {
        private readonly TreatmentMachineState _state = new TreatmentMachineState();
        public TreatmentMachineAggregate(TreatmentMachineId id) : base(id)
        {
            Register(_state);
        }

        public void AddMachineWithSimpleCapability(Name name)
        {
            Specs.AggregateIsNew.ThrowDomainErrorIfNotSatisfied(this);
            //Uniqueness check specification
            Emit(new TreatmentMachineWithSimpleCapabilityIsAddedEvent(Id, name));
        }

        public void AddMachineWithAdvancedCapability(Name name)
        {
            Specs.AggregateIsNew.ThrowDomainErrorIfNotSatisfied(this);
            //Uniqueness check specification
            Emit(new TreatmentMachineWithAdvancedCapabilityIsAddedEvent(Id, name));
        }
    }
}
