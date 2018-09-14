using EventFlow.Aggregates;
using Simulator.Domain.Common;
using Simulator.Domain.TreatmentMachine.Events;

namespace Simulator.Domain.TreatmentMachine
{
    internal sealed class TreatmentMachineState : AggregateState<TreatmentMachineAggregate, TreatmentMachineId, TreatmentMachineState>,
        IApply<TreatmentMachineWithSimpleCapabilityIsAddedEvent>,
        IApply<TreatmentMachineWithAdvancedCapabilityIsAddedEvent>
    {
        public Name  Name { get; private set; }

        public void Apply(TreatmentMachineWithSimpleCapabilityIsAddedEvent aggregateEvent)
        {
            Name = aggregateEvent.Name;
        }

        public void Apply(TreatmentMachineWithAdvancedCapabilityIsAddedEvent aggregateEvent)
        {
            Name = aggregateEvent.Name;
        }
    }
}