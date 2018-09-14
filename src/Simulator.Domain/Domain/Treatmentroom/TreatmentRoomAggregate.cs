using System;

using EventFlow.Aggregates;
using EventFlow.Extensions;

using Simulator.Domain.Common;
using Simulator.Domain.TreatmentMachine;
using Simulator.Domain.Treatmentroom.Events;

namespace Simulator.Domain.Treatmentroom
{
    public sealed class TreatmentRoomAggregate: AggregateRoot<TreatmentRoomAggregate, TreatmentRoomId>
    {
        internal readonly TreatmentRoomState _state = new TreatmentRoomState();
        public TreatmentRoomAggregate(TreatmentRoomId id) : base(id)
        {
            Register(_state);
        }

        public void Add(Name name)
        {
            Specs.AggregateIsNew.ThrowDomainErrorIfNotSatisfied(this);
            Emit(new TreatmentRoomIsAddedEvent(name));
        }

        public void EquipWithTreatmentMachine(TreatmentMachineId treatmentMachineId)
        {
            Specs.AggregateIsCreated.ThrowDomainErrorIfNotSatisfied(this);

            //TODO: If room is already equipped with a machine then raise UnEquippedRoomWithAMachineEvent(..)

            Emit(new TreatmentRoomIsEquippedWithMachineEvent(treatmentMachineId));
        }

        public void ReserveRoom(DateTime reservationDay, string referenceId)
        {
            Specs.AggregateIsCreated.ThrowDomainErrorIfNotSatisfied(this);
            //spec, there should not be a reservation on same day
            Emit(new TreatmentRoomIsReservedEvent(Id, reservationDay, referenceId));
        }
    }
}
