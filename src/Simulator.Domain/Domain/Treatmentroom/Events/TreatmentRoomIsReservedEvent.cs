using System;

using EventFlow.Aggregates;

using Newtonsoft.Json;

namespace Simulator.Domain.Treatmentroom.Events
{
    public sealed class TreatmentRoomIsReservedEvent : AggregateEvent<TreatmentRoomAggregate, TreatmentRoomId>
    {
        public readonly TreatmentRoomId Id;
        public readonly DateTime ReservationDay;
        public readonly string ReferenceId;

        [JsonConstructor]
        public TreatmentRoomIsReservedEvent(TreatmentRoomId id, DateTime reservationDay, string referenceId)
        {
            Id = id;
            ReservationDay = reservationDay;
            ReferenceId = referenceId;
        }
    }
}