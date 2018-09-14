using EventFlow.Queries;

using Simulator.Domain.Common;

namespace Simulator.Query.TreatmentMachine
{
    public sealed class GetTreatmentMachineByNameQuery : IQuery<TreatmentMachineReadModel>
    {
        public readonly Name Name;
        public GetTreatmentMachineByNameQuery(Name name)
        {
            Name = name;
        }

        public bool ThrowIfNotFound { get; }
    }
}
