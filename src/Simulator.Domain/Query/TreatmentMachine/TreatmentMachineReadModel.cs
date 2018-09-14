using EventFlow.Aggregates;
using EventFlow.ReadStores;
using Simulator.Domain.Common;
using Simulator.Domain.TreatmentMachine;
using Simulator.Domain.TreatmentMachine.Events;

namespace Simulator.Query.TreatmentMachine
{
    public sealed class TreatmentMachineReadModel : IVersionedReadModel,
        IAmReadModelFor<TreatmentMachineAggregate, TreatmentMachineId, TreatmentMachineWithSimpleCapabilityIsAddedEvent>,
        IAmReadModelFor<TreatmentMachineAggregate, TreatmentMachineId, TreatmentMachineWithAdvancedCapabilityIsAddedEvent>
    {
        public Name Name { get; private set; }

        public bool HasAdvancedCapability { get; private set; }
        public bool HasSimpleCapability { get; private set; }

        public void Apply(IReadModelContext context,
            IDomainEvent<TreatmentMachineAggregate, TreatmentMachineId, TreatmentMachineWithSimpleCapabilityIsAddedEvent> domainEvent)
        {
            Id = domainEvent.AggregateEvent.Id.Value;
            Name = domainEvent.AggregateEvent.Name;
            HasSimpleCapability = true;
        }

        public string Id { get; private set; }
        public long? Version { get; set; }

        public void Apply(IReadModelContext context, IDomainEvent<TreatmentMachineAggregate, TreatmentMachineId, TreatmentMachineWithAdvancedCapabilityIsAddedEvent> domainEvent)
        {
            Id = domainEvent.AggregateEvent.Id.Value;
            Name = domainEvent.AggregateEvent.Name;
            HasAdvancedCapability = true;
        }
    }
}