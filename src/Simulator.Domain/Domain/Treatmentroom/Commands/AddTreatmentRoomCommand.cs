using EventFlow.Commands;

using Simulator.Domain.Common;

namespace Simulator.Domain.Treatmentroom.Commands
{
    public sealed class AddTreatmentRoomCommand : Command<TreatmentRoomAggregate, TreatmentRoomId>
    {
        public Name Name{ get; }

        public AddTreatmentRoomCommand(TreatmentRoomId aggregateId,  Name name) : base(aggregateId)
        {
            Name = name;
        }
    }
}