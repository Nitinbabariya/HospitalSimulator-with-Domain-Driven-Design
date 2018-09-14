using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EventFlow.Aggregates;
using EventFlow.ReadStores;

using Simulator.Domain.Common;
using Simulator.Domain.Doctor;
using Simulator.Domain.Doctor.Events;

namespace Simulator.Query.Doctor
{
    public sealed class DoctorReadModel : IReadModel,
        IAmReadModelFor<DoctorAggregate, DoctorId, DoctorIsAddedEvent>,
        IAmReadModelFor<DoctorAggregate, DoctorId, DoctorIsReservedEvent>,
        IAmReadModelFor<DoctorAggregate, DoctorId, DoctorReservationIsRejectedEvent>
    {
        public DoctorReadModel()
        {
            _Reservations = new List<DateTime>();
        }

        public string Id{ get; private set; }
        public string Name { get; private set; }
        public IReadOnlyCollection<Role> Roles{ get; private set; }
        private List<DateTime> _Reservations { get; }
        public IReadOnlyCollection<DateTime> Reservations => _Reservations.AsReadOnly();

        public void Apply(IReadModelContext context, IDomainEvent<DoctorAggregate, DoctorId, DoctorIsAddedEvent> domainEvent)
        {
            Id = domainEvent.AggregateIdentity.Value;
            Name = domainEvent.AggregateEvent.Name;
            Roles = domainEvent.AggregateEvent.Roles.ToList();
        }

        public void Apply(IReadModelContext context, IDomainEvent<DoctorAggregate, DoctorId, DoctorIsReservedEvent> domainEvent)
        {
            _Reservations.Add(domainEvent.AggregateEvent.ReservationDay);
        }

        public void Apply(IReadModelContext context, IDomainEvent<DoctorAggregate, DoctorId, DoctorReservationIsRejectedEvent> domainEvent)
        {
            _Reservations.Remove(domainEvent.AggregateEvent.ReservationDay);
        }
    }
}