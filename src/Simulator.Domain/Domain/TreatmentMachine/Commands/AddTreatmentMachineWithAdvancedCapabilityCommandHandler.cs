using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EventFlow.Commands;
using EventFlow.Exceptions;
using EventFlow.Queries;
using EventFlow.Specifications;

using Simulator.Domain.Treatmentroom;
using Simulator.Query.TreatmentMachine;

namespace Simulator.Domain.TreatmentMachine.Commands
{
    internal sealed class AddTreatmentMachineWithAdvancedCapabilityCommandHandler : CommandHandler<TreatmentMachineAggregate, TreatmentMachineId, AddTreatmentMachineWithAdvanceCapabilityCommand>
    {
        private readonly IQueryProcessor _queryProcessor;

        public AddTreatmentMachineWithAdvancedCapabilityCommandHandler(IQueryProcessor queryProcessor)
        {
            this._queryProcessor = queryProcessor;
        }

        public override async Task ExecuteAsync(TreatmentMachineAggregate aggregate, AddTreatmentMachineWithAdvanceCapabilityCommand command,
            CancellationToken cancellationToken)
        {
            var query = new GetTreatmentMachineByNameQuery(command.Name);
            if (await _queryProcessor.ProcessAsync(query, cancellationToken).ConfigureAwait(false) != null)
            {
                throw DomainError.With($"Treatment machine with name '{command.Name}' already exists.");
            }

            aggregate.AddMachineWithAdvancedCapability(command.Name);
        }
    }
}