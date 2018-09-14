using EventFlow.Commands;
using Simulator.Domain.Common;

namespace Simulator.Domain.TreatmentMachine.Commands
{
    public sealed class AddTreatmentMachineWithAdvanceCapabilityCommand : Command<TreatmentMachineAggregate, TreatmentMachineId>
    {
        public Name Name { get; }

        public AddTreatmentMachineWithAdvanceCapabilityCommand(TreatmentMachineId aggregateId, Name name) : base(aggregateId)
        {
            Name = name;
        }
    }
}