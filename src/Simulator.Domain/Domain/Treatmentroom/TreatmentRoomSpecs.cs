using System;
using System.Collections.Generic;

using EventFlow.Specifications;

using Simulator.Domain.Doctor;

namespace Simulator.Domain.Treatmentroom
{
    internal static class TreatmentRoomSpecs
    {
        public static  ISpecification<TreatmentRoomAggregate> HasNoReservationOnTheDayOf(DateTime day) => new IsNotAlreadyReserved(day);

        private class IsNotAlreadyReserved : Specification<TreatmentRoomAggregate>
        {
            private readonly DateTime _day;

            public IsNotAlreadyReserved(DateTime day)
            {
                _day = day;
            }

            protected override IEnumerable<string> IsNotSatisfiedBecause(TreatmentRoomAggregate obj)
            {
                if (obj._state.Reservations.Contains(_day))
                {
                    yield return $"Treatmentroom {obj.Id} has already been reserved for {_day} day";
                }
            }

        }
    }
}