using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using EventFlow.Queries;
using EventFlow.ReadStores.InMemory;

namespace Simulator.Query.Patient
{
    internal sealed class GetPatientByIdQueryHandler : IQueryHandler<GetPatientsQuery, IReadOnlyCollection<PatientReadModel>>
    {
        private readonly IInMemoryReadStore<PatientReadModel> _store;

        public GetPatientByIdQueryHandler(IInMemoryReadStore<PatientReadModel> _store)
        {
            this._store = _store;
        }

        public Task<IReadOnlyCollection<PatientReadModel>> ExecuteQueryAsync(GetPatientsQuery query, CancellationToken cancellationToken)
        {
            return _store.FindAsync(query.Predicate, cancellationToken);
        }
    }
}