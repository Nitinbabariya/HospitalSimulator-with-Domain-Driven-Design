using System.Collections.Generic;
using EventFlow.Aggregates;
using EventFlow.EventStores;
using Simulator.Domain.Common;

namespace Simulator.Domain.Doctor.Events
{
    [EventVersion("DoctorIsAddedEvent", 1)]

    public sealed class DoctorIsAddedEvent: AggregateEvent<DoctorAggregate, DoctorId>
    {
        public readonly Name Name;
        public readonly IEnumerable<Role> Roles;

        public DoctorIsAddedEvent(Name name, IEnumerable<Role>roles)
        {
            Name = name;
            Roles = roles??new List<Role>();
        }
    }
}