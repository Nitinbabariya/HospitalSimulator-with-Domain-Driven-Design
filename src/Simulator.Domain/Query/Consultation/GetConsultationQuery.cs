using System;
using System.Collections.Generic;

using EventFlow.Queries;

namespace Simulator.Query.Consultation
{
    public sealed class GetConsultationQuery: IQuery<IReadOnlyCollection<ConsultationReadModel>>
    {
        public readonly Predicate<ConsultationReadModel> Predicate;

        internal GetConsultationQuery(Predicate<ConsultationReadModel> predicate)
        {
            Predicate = predicate;
        }
    }
}
