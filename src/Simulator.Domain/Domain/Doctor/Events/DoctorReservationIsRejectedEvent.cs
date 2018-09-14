using System;
using EventFlow.Aggregates;
using EventFlow.EventStores;

using Newtonsoft.Json;

namespace Simulator.Domain.Doctor.Events
{
    [EventVersion("DoctorReservationIsRejectedEvent", 1)]

    public sealed class DoctorReservationIsRejectedEvent : AggregateEvent<DoctorAggregate, DoctorId>
    {
        public readonly DoctorId Id;
        public readonly DateTime ReservationDay;
        public readonly string ReferenceId;

        [JsonConstructor]
        public DoctorReservationIsRejectedEvent(DoctorId id, DateTime reservationDay, string referenceId)
        {
            Id = id;
            ReservationDay = reservationDay;
            ReferenceId = referenceId;
        }
    }
}