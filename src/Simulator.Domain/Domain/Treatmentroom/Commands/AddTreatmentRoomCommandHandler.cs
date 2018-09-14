using System.Threading;
using System.Threading.Tasks;

using EventFlow.Commands;
using EventFlow.Exceptions;
using EventFlow.Queries;

using Simulator.Query.TreatmentRoom;

namespace Simulator.Domain.Treatmentroom.Commands
{
    internal sealed class AddTreatmentRoomCommandHandler : CommandHandler<TreatmentRoomAggregate, TreatmentRoomId, AddTreatmentRoomCommand>
    {
        private readonly IQueryProcessor queryProcessor;

        public AddTreatmentRoomCommandHandler(IQueryProcessor queryProcessor)
        {
            this.queryProcessor = queryProcessor;
        }

        public override async Task ExecuteAsync(TreatmentRoomAggregate aggregate, AddTreatmentRoomCommand command,
            CancellationToken cancellationToken)
        {
            var query = new GetTreatmentRoomByNameQuery(command.Name);
            if (await this.queryProcessor.ProcessAsync(query, cancellationToken) != null)
            {
                throw DomainError.With($"Treatment room with name '{command.Name}' already exists.");
            }

            aggregate.Add(command.Name);
        }
    }
}