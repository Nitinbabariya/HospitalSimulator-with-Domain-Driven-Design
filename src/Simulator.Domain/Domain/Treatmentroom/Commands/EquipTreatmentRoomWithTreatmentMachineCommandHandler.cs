using System.Threading;
using System.Threading.Tasks;

using EventFlow.Commands;

namespace Simulator.Domain.Treatmentroom.Commands
{
    internal sealed class EquipTreatmentRoomWithTreatmentCommandHandler : CommandHandler<TreatmentRoomAggregate, TreatmentRoomId, EquipTreatmentRoomWithMachineCommand>
    {
        public override async Task ExecuteAsync(TreatmentRoomAggregate aggregate, EquipTreatmentRoomWithMachineCommand command,
            CancellationToken cancellationToken)
        {
            aggregate.EquipWithTreatmentMachine(command.TreatmentMachineId);
        }
    }
}