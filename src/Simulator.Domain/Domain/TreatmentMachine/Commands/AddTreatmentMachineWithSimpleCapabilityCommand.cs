using System.Threading;
using System.Threading.Tasks;
using EventFlow.Commands;
using EventFlow.Exceptions;
using EventFlow.Queries;
using Simulator.Domain.Common;

namespace Simulator.Domain.TreatmentMachine.Commands
{
    public sealed class AddTreatmentMachineWithSimpleCapabilityCommand : Command<TreatmentMachineAggregate, TreatmentMachineId>
    {
        public Name Name { get; }
        public AddTreatmentMachineWithSimpleCapabilityCommand(TreatmentMachineId aggregateId, Name name) : base(aggregateId)
        {
            Name = name;
        }
    }
}