using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using EventFlow.Queries;
using EventFlow.ReadStores.InMemory;

namespace Simulator.Query.Doctor
{
    internal sealed class GetDoctorsQueryHandler : IQueryHandler<GetDoctorsQuery, IReadOnlyCollection<DoctorReadModel>>
    {
        private readonly IInMemoryReadStore<DoctorReadModel> _store;

        public GetDoctorsQueryHandler(IInMemoryReadStore<DoctorReadModel> _store)
        {
            this._store = _store;
        }

        public Task<IReadOnlyCollection<DoctorReadModel>> ExecuteQueryAsync(GetDoctorsQuery query, CancellationToken cancellationToken)
        {
            return _store.FindAsync(query.Predicate, cancellationToken);
        }
    }
}