using System;
using System.Collections.Generic;

using EventFlow.Specifications;

namespace Simulator.Domain.Doctor
{
    internal static class DoctorSpecs
    {
        public static  ISpecification<DoctorAggregate> HasNoReservationOnTheDayOf(DateTime day) => new IsNotAlreadyReserved(day);

        private class IsNotAlreadyReserved : Specification<DoctorAggregate>
        {
            private readonly DateTime _day;

            public IsNotAlreadyReserved(DateTime day)
            {
                _day = day;
            }

            protected override IEnumerable<string> IsNotSatisfiedBecause(DoctorAggregate obj)
            {
                if (obj._state.Reservations.Contains(_day))
                {
                    yield return $"Doctor {obj.Id} has already been reserved for {_day} day";
                }
            }

        }
    }
}