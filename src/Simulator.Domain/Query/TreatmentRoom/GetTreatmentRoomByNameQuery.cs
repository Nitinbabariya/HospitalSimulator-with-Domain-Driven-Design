using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EventFlow.Queries;
using EventFlow.ReadStores.InMemory;
using Simulator.Domain.Common;
using Simulator.Query.TreatmentRoom;

namespace Simulator.Query.TreatmentRoom
{
    public sealed class GetTreatmentRoomByNameQuery : IQuery<TreatmentRoomReadModel>
    {
        public readonly Name Name;
        public GetTreatmentRoomByNameQuery(Name name)
        {
            Name = name;
        }

        public bool ThrowIfNotFound { get; }
    }

    public sealed class GetTreatmentRoomByNameQueryHandler : IQueryHandler<GetTreatmentRoomByNameQuery, TreatmentRoomReadModel>
    {
        private readonly IInMemoryReadStore<TreatmentRoomReadModel> _store;

        public GetTreatmentRoomByNameQueryHandler(IInMemoryReadStore<TreatmentRoomReadModel> _store)
        {
            this._store = _store;
        }

        public async Task<TreatmentRoomReadModel> ExecuteQueryAsync(GetTreatmentRoomByNameQuery query, CancellationToken cancellationToken)
        {
            var treatmentRooms = await _store.FindAsync(rm => (rm.Name == query.Name), cancellationToken).ConfigureAwait(false);
            var rooms = treatmentRooms.ToArray();

            switch (rooms.Length)
            {
                case 0:
                    if (query.ThrowIfNotFound)
                    {
                        throw new Exception("Not found.");
                    }
                    else
                    {
                        return null;
                    }

                case 1:
                    return rooms.Single();
                default:
                    throw new MultipleTreatmentMachinesWithSameNameException();
            }
        }
    }
}
