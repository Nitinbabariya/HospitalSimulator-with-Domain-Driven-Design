using System;
using System.Collections.Generic;
using System.Linq;

using EventFlow.Queries;

using Simulator.Domain.Patient;

namespace Simulator.Query.Patient
{
    public sealed class GetPatientsQuery : IQuery<IReadOnlyCollection<PatientReadModel>>
    {
        public readonly Predicate<PatientReadModel> Predicate;

        internal GetPatientsQuery(Predicate<PatientReadModel> predicate)
        {
            Predicate = predicate;
        }
    }
}
