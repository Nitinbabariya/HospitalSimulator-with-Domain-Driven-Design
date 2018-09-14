using EventFlow.Commands;

using Simulator.Domain.TreatmentMachine;

namespace Simulator.Domain.Treatmentroom.Commands
{
    public sealed class EquipTreatmentRoomWithMachineCommand : Command<TreatmentRoomAggregate, TreatmentRoomId>
    {
        public readonly TreatmentMachineId TreatmentMachineId;

        public EquipTreatmentRoomWithMachineCommand(TreatmentRoomId aggregateId,  TreatmentMachineId treatmentMachineId) : base(aggregateId)
        {
            TreatmentMachineId = treatmentMachineId;
        }
    }
}