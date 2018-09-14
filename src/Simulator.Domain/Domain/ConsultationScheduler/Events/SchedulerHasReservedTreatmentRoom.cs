using System;
using EventFlow.Aggregates;

using Simulator.Domain.Treatmentroom;

namespace Simulator.Domain.ConsultationScheduler.Events
{
    public sealed class SchedulerHasReservedTreatmentRoom : AggregateEvent<ConsultationSchedulerSaga, ConsultationSchedulerSagaId>
    {
        public TreatmentRoomId TreatmentRoomId { get; }
        public DateTime ReservationDay { get; }
        public SchedulerHasReservedTreatmentRoom(TreatmentRoomId treatmentRoomId, DateTime reservationDay)
        {
            TreatmentRoomId = treatmentRoomId;
            ReservationDay = reservationDay;
        }
    }
}