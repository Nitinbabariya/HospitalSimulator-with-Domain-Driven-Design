using System.Threading;
using System.Threading.Tasks;

using EventFlow.Commands;
using EventFlow.Queries;

namespace Simulator.Domain.Treatmentroom.Commands
{
    internal sealed class ReserveTreatmentRoomCommandHandler : CommandHandler<TreatmentRoomAggregate, TreatmentRoomId, ReserveTreatmentRoomCommand>
    {
        private readonly IQueryProcessor queryProcessor;

        public ReserveTreatmentRoomCommandHandler(IQueryProcessor queryProcessor)
        {
            this.queryProcessor = queryProcessor;
        }

        public override async Task ExecuteAsync(TreatmentRoomAggregate aggregate, ReserveTreatmentRoomCommand command,
            CancellationToken cancellationToken)
        {
            aggregate.ReserveRoom(command.ReservationDay, command.ReferenceId);
        }
    }
}