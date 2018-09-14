using System;

using EventFlow.Commands;

namespace Simulator.Domain.Doctor.Commands
{
    public sealed class ReserveDoctorCommand : Command<DoctorAggregate, DoctorId>
    {
        public readonly DateTime ReservationDay;
        public readonly string ReferenceId;

        //TODO:Validate command
        public ReserveDoctorCommand(DoctorId aggregateId, DateTime reservationDay, string referenceId) : base(aggregateId)
        {
            ReservationDay = reservationDay;
            ReferenceId = referenceId;
        }
    }
}