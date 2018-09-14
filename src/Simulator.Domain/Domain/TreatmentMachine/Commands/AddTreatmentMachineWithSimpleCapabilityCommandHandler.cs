using System.Threading;
using System.Threading.Tasks;
using EventFlow.Commands;
using EventFlow.Exceptions;
using EventFlow.Queries;
using Simulator.Query.TreatmentMachine;

namespace Simulator.Domain.TreatmentMachine.Commands
{
    internal sealed class AddTreatmentMachineWithSimpleCapabilityCommandHandler : CommandHandler<TreatmentMachineAggregate, TreatmentMachineId, AddTreatmentMachineWithSimpleCapabilityCommand>
    {
        private readonly IQueryProcessor _queryProcessor;

        public AddTreatmentMachineWithSimpleCapabilityCommandHandler(IQueryProcessor queryProcessor)
        {
            this._queryProcessor = queryProcessor;
        }

        public override async Task ExecuteAsync(TreatmentMachineAggregate aggregate, AddTreatmentMachineWithSimpleCapabilityCommand command,
            CancellationToken cancellationToken)
        {
            var query = new GetTreatmentMachineByNameQuery(command.Name);
            if (await _queryProcessor.ProcessAsync(query, cancellationToken).ConfigureAwait(false)  != null)
            {
                throw DomainError.With($"Treatment machine with name '{command.Name}' already exists.");
            }

            aggregate.AddMachineWithSimpleCapability(command.Name);
        }
    }
}