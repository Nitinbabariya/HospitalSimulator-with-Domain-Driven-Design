
using System;
using System.Collections.Generic;
using EventFlow.Aggregates;
using EventFlow.ReadStores;
using Simulator.Domain.Common;
using Simulator.Domain.TreatmentMachine;
using Simulator.Domain.Treatmentroom;
using Simulator.Domain.Treatmentroom.Events;

namespace Simulator.Query.TreatmentRoom
{
    public sealed class TreatmentRoomReadModel : IReadModel,
        IAmReadModelFor<TreatmentRoomAggregate, TreatmentRoomId, TreatmentRoomIsAddedEvent>,
        IAmReadModelFor<TreatmentRoomAggregate, TreatmentRoomId, TreatmentRoomIsEquippedWithMachineEvent>,
        IAmReadModelFor<TreatmentRoomAggregate, TreatmentRoomId, TreatmentRoomIsReservedEvent>
    {
        public TreatmentRoomReadModel()
        {
            _Reservations = new List<DateTime>();
        }

        public TreatmentRoomId  Id{ get; private set; }
        public Name  Name { get; private set; }
        public TreatmentMachineId TreatmentMachineId { get; private set; }
        private List<DateTime> _Reservations { get; }
        public IReadOnlyCollection<DateTime> Reservations => _Reservations.AsReadOnly();

        public void Apply(IReadModelContext context, IDomainEvent<TreatmentRoomAggregate, TreatmentRoomId, TreatmentRoomIsAddedEvent> domainEvent)
        {
            Id = domainEvent.AggregateIdentity;
            Name = domainEvent.AggregateEvent.Name;
        }

        public void Apply(IReadModelContext context, IDomainEvent<TreatmentRoomAggregate, TreatmentRoomId, TreatmentRoomIsEquippedWithMachineEvent> domainEvent)
        {
            TreatmentMachineId = domainEvent.AggregateEvent.TreatmentMachineId;
        }

        public void Apply(IReadModelContext context, IDomainEvent<TreatmentRoomAggregate, TreatmentRoomId, TreatmentRoomIsReservedEvent> domainEvent)
        {
            _Reservations.Add(domainEvent.AggregateEvent.ReservationDay);
        }
    }
}