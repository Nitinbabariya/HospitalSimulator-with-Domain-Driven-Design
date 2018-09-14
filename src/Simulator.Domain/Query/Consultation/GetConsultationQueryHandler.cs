using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using EventFlow.Queries;
using EventFlow.ReadStores.InMemory;

namespace Simulator.Query.Consultation
{
    internal sealed class GetConsultationQueryHandler : IQueryHandler<GetConsultationQuery, IReadOnlyCollection<ConsultationReadModel>>
    {
        private readonly IInMemoryReadStore<ConsultationReadModel> _store;

        public GetConsultationQueryHandler(IInMemoryReadStore<ConsultationReadModel> _store)
        {
            this._store = _store;
        }

        public Task<IReadOnlyCollection<ConsultationReadModel>> ExecuteQueryAsync(GetConsultationQuery query, CancellationToken cancellationToken)
        {
            return _store.FindAsync(query.Predicate, cancellationToken);
        }
    }
}