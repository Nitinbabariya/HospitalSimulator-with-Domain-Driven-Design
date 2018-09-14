using System;
using System.Collections.Generic;

using EventFlow.Queries;

namespace Simulator.Query.Doctor
{
    public sealed class GetDoctorsQuery : IQuery<IReadOnlyCollection<DoctorReadModel>>
    {
        public readonly Predicate<DoctorReadModel> Predicate;

        internal GetDoctorsQuery(Predicate<DoctorReadModel> predicate)
        {
            Predicate = predicate;
        }
    }
}
