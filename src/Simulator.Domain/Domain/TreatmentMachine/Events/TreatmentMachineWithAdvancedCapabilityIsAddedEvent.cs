using EventFlow.Aggregates;
using EventFlow.EventStores;
using Simulator.Domain.Common;

namespace Simulator.Domain.TreatmentMachine.Events
{
    [EventVersion("TreatmentMachineWithAdvancedCapabilityIsAddedEvent", 1)]
    public sealed class TreatmentMachineWithAdvancedCapabilityIsAddedEvent : AggregateEvent<TreatmentMachineAggregate, TreatmentMachineId>
    {
        public TreatmentMachineId Id { get; private set; }
        public Name Name { get; }
        public TreatmentMachineWithAdvancedCapabilityIsAddedEvent(TreatmentMachineId id, Name name)
        {
            Id = id;
            Name = name;
        }
    }
}