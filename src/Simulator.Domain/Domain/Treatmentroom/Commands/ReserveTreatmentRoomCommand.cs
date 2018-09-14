using System;

using EventFlow.Commands;

namespace Simulator.Domain.Treatmentroom.Commands
{
    public sealed class ReserveTreatmentRoomCommand : Command<TreatmentRoomAggregate, TreatmentRoomId>
    {
        public readonly DateTime ReservationDay;
        public readonly string ReferenceId;

        public ReserveTreatmentRoomCommand(TreatmentRoomId aggregateId,  DateTime reservationDay, string referenceId) : base(aggregateId)
        {
            ReservationDay = reservationDay;
            ReferenceId = referenceId;
        }
    }

}