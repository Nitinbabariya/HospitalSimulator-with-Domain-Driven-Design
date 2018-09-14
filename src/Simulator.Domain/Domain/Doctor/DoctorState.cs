using System;
using System.Collections.Generic;
using System.Linq;

using EventFlow.Aggregates;

using Simulator.Domain.Common;
using Simulator.Domain.Doctor.Events;

namespace Simulator.Domain.Doctor
{
    internal sealed class DoctorState : AggregateState<DoctorAggregate, DoctorId, DoctorState>,
        IApply<DoctorIsAddedEvent>,
        IApply<DoctorIsReservedEvent>,
        IApply<DoctorReservationIsRejectedEvent>
    {
        internal Name Name { get; set; }

        internal List<Role> Roles { get; set; }

        internal List<DateTime> Reservations { get;  set; }

        public void Apply(DoctorIsAddedEvent aggregateEvent)
        {
            Name = aggregateEvent.Name;
            Reservations = new List<DateTime>();

            Roles = aggregateEvent.Roles.ToList();
        }

        public void Apply(DoctorIsReservedEvent aggregateEvent)
        {
            Reservations.Add(aggregateEvent.ReservationDay);

        }

        public void Apply(DoctorReservationIsRejectedEvent aggregateEvent)
        {
            Reservations.Remove(aggregateEvent.ReservationDay);
        }
    }
}