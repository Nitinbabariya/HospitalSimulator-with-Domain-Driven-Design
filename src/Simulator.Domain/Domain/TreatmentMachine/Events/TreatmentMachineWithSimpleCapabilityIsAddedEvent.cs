using EventFlow.Aggregates;
using EventFlow.EventStores;
using Simulator.Domain.Common;

namespace Simulator.Domain.TreatmentMachine.Events
{
    [EventVersion("TreatmentMachineWithSimpleCapabilityIsAddedEvent", 1)]
    public sealed class TreatmentMachineWithSimpleCapabilityIsAddedEvent : AggregateEvent<TreatmentMachineAggregate, TreatmentMachineId>
    {
        public TreatmentMachineId Id { get; private set; }
        public Name Name { get; }

        public TreatmentMachineWithSimpleCapabilityIsAddedEvent(TreatmentMachineId id, Name name)
        {
            Id = id;
            Name = name;
        }
    }
}