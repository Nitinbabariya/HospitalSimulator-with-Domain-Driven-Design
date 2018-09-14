using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using EventFlow.Queries;
using EventFlow.ReadStores.InMemory;

namespace Simulator.Query.TreatmentMachine
{
    internal sealed class GetTreatmentmachineQueryHandler : IQueryHandler<GetTreatmentMachineByNameQuery, TreatmentMachineReadModel>
    {
        private readonly IInMemoryReadStore<TreatmentMachineReadModel> _store;

        public GetTreatmentmachineQueryHandler(IInMemoryReadStore<TreatmentMachineReadModel> _store)
        {
            this._store = _store;
        }

        public async Task<TreatmentMachineReadModel> ExecuteQueryAsync(GetTreatmentMachineByNameQuery query, CancellationToken cancellationToken)
        {
            var treatmentMachines = await _store.FindAsync(rm => (rm.Name == query.Name), cancellationToken).ConfigureAwait(false);
            var machines = treatmentMachines.ToArray();

            switch (machines.Length)
            {
                case 0:
                    if (query.ThrowIfNotFound)
                    {
                        throw EventFlow.Exceptions.DomainError.With("Not found.");
                    }
                    else
                    {
                        return null;
                    }

                case 1:
                    return machines.Single();
                default:
                    throw new MultipleTreatmentMachinesWithSameNameException();
            }
        }
    }
}