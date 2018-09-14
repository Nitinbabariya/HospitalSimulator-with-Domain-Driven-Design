using System;
using System.Collections.Generic;

using EventFlow.Aggregates;

using Simulator.Domain.Common;
using Simulator.Domain.TreatmentMachine;
using Simulator.Domain.Treatmentroom.Events;

namespace Simulator.Domain.Treatmentroom
{
    internal sealed class TreatmentRoomState : AggregateState<TreatmentRoomAggregate, TreatmentRoomId, TreatmentRoomState>,
        IApply<TreatmentRoomIsAddedEvent>,
        IApply<TreatmentRoomIsEquippedWithMachineEvent>,
        IApply<TreatmentRoomIsReservedEvent>
    {
        public Name Name{ get; private set;}
        public TreatmentMachineId TreatmentMachineId{ get; private set; }

        internal List<DateTime> Reservations{ get;  set; }

        public void Apply(TreatmentRoomIsAddedEvent aggregateEvent)
        {
            Name = aggregateEvent.Name;
            Reservations=new List<DateTime>();
        }

        public void Apply(TreatmentRoomIsEquippedWithMachineEvent aggregateEvent)
        {
            TreatmentMachineId = aggregateEvent.TreatmentMachineId;
        }

        public void Apply(TreatmentRoomIsReservedEvent aggregateEvent)
        {
            Reservations.Add(aggregateEvent.ReservationDay);
        }
    }
}