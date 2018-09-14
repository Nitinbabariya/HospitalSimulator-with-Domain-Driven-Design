using System;

using EventFlow.Aggregates;

using Newtonsoft.Json;

namespace Simulator.Domain.Treatmentroom.Events
{
    public sealed class TreatmentRoomReservationIsRejectedEvent : AggregateEvent<TreatmentRoomAggregate, TreatmentRoomId>
    {
        public readonly DateTime ReservationDay;

        [JsonConstructor]
        public TreatmentRoomReservationIsRejectedEvent(DateTime reservationDay)
        {
            ReservationDay = reservationDay;
        }
    }
}