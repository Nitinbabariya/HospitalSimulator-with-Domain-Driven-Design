using System;
using EventFlow.Aggregates;
using Simulator.Domain.Doctor;

namespace Simulator.Domain.ConsultationScheduler.Events
{
    public sealed class SchedulerHasReservedDoctorEvent : AggregateEvent<ConsultationSchedulerSaga, ConsultationSchedulerSagaId>
    {
        public readonly DoctorId DoctorId;
        public readonly DateTime ReservationDay;

        public SchedulerHasReservedDoctorEvent(DoctorId doctorId, DateTime reservationDay)
        {
            DoctorId = doctorId;
            ReservationDay = reservationDay;
        }
    }
}