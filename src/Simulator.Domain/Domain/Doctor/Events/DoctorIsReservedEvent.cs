using System;
using EventFlow.Aggregates;
using EventFlow.EventStores;

using Newtonsoft.Json;

namespace Simulator.Domain.Doctor.Events
{
    [EventVersion("DoctorIsReservedEvent", 1)]

    public sealed class DoctorIsReservedEvent : AggregateEvent<DoctorAggregate, DoctorId>
    {
        public readonly DoctorId Id;
        public readonly DateTime ReservationDay;
        public readonly string ReferenceId;

        [JsonConstructor]
        public DoctorIsReservedEvent(DoctorId id, DateTime reservationDay, string referenceId)
        {
            Id = id;
            ReservationDay = reservationDay;
            ReferenceId = referenceId;
        }
    }
}