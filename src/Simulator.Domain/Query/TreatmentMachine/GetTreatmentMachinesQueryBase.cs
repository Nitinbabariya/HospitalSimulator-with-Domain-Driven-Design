using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EventFlow.Queries;
using EventFlow.ReadStores.InMemory;
using Simulator.Domain.Doctor;

namespace Simulator.Query.TreatmentMachine
{
    public sealed class GetTreatmentMachinesQuery : IQuery<IReadOnlyCollection<TreatmentMachineReadModel>>
    {
        public readonly Predicate<TreatmentMachineReadModel> Predicate;

        public GetTreatmentMachinesQuery(Predicate<TreatmentMachineReadModel> predicate)
        {
            Predicate = predicate;
        }
    }

    public sealed class GetTreatmentMachinesQueryHandler : IQueryHandler<GetTreatmentMachinesQuery, IReadOnlyCollection<TreatmentMachineReadModel>>
    {
        private readonly IInMemoryReadStore<TreatmentMachineReadModel> _store;

        public GetTreatmentMachinesQueryHandler(IInMemoryReadStore<TreatmentMachineReadModel> store)
        {
            this._store = store;
        }

        public Task<IReadOnlyCollection<TreatmentMachineReadModel>> ExecuteQueryAsync(GetTreatmentMachinesQuery query, CancellationToken cancellationToken)
        {
             return _store.FindAsync(query.Predicate, cancellationToken);
        }
    }
}
