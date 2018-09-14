using System;
using System.Collections.Generic;
using EventFlow.Aggregates;
using EventFlow.Extensions;

using Simulator.Domain.Doctor.Events;

namespace Simulator.Domain.Doctor
{
    public sealed class DoctorAggregate:AggregateRoot<DoctorAggregate,DoctorId>
    {
        internal readonly DoctorState _state = new DoctorState();
        public DoctorAggregate(DoctorId id) : base(id)
        {
            Register(_state);
        }

        public void Add(string name, IEnumerable<Role> roles)
        {
            Specs.AggregateIsNew.ThrowDomainErrorIfNotSatisfied(this);
            Emit(new DoctorIsAddedEvent(name, roles));
        }

        public void ReserveDoctor(DateTime reservationDay, string referenceId)
        {
            if (Specs.AggregateIsCreated.And(DoctorSpecs.HasNoReservationOnTheDayOf(reservationDay)).IsSatisfiedBy(this))
            {
                Emit(new DoctorIsReservedEvent(Id, reservationDay, referenceId));
            }
            else
            {
                Emit(new DoctorReservationIsRejectedEvent(Id, reservationDay, referenceId));
            }
        }
    }
}