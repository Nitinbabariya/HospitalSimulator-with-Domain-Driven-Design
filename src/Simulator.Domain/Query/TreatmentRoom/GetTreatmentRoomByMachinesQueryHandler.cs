using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using EventFlow.Queries;
using EventFlow.ReadStores.InMemory;

namespace Simulator.Query.TreatmentRoom
{
    internal class GetTreatmentRoomByMachinesQueryHandler : IQueryHandler<GetTreatmentRoomQuery, IReadOnlyCollection<TreatmentRoomReadModel>>
    {
        private readonly IInMemoryReadStore<TreatmentRoomReadModel> _store;

        public GetTreatmentRoomByMachinesQueryHandler(IInMemoryReadStore<TreatmentRoomReadModel> store)
        {
            this._store = store;
        }

        public async Task<IReadOnlyCollection<TreatmentRoomReadModel>> ExecuteQueryAsync(GetTreatmentRoomQuery query, CancellationToken cancellationToken)
        {
            var treatmentRooms = await _store.FindAsync(query.Predicate,cancellationToken).ConfigureAwait(false);
            return treatmentRooms;
        }
    }
}