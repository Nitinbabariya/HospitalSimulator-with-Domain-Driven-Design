using System;
using EventFlow.Aggregates;
using Simulator.Domain.ConsultationScheduler.Events;
using Simulator.Domain.Doctor;
using Simulator.Domain.Patient;
using Simulator.Domain.Treatmentroom;

namespace Simulator.Domain.ConsultationScheduler
{
    internal sealed class ConsultationSchedulerState : AggregateState<ConsultationSchedulerSaga, ConsultationSchedulerSagaId, ConsultationSchedulerState>,
        IApply<ConsultationSchedulingIsStartedEvent>,
        IApply<SchedulerHasReservedTreatmentRoom>,
        IApply<SchedulerHasReservedDoctorEvent>,
        IApply<ConsultationSchedulingIsCompletedEvent>
    {
        public PatientId PatientId { get; private set; }
        public DoctorId DoctorId { get; private set; }
        public TreatmentRoomId TreatmentRoomId{ get; private set; }
        public DateTime PatientRegistrationDate { get; private set; }
        public DateTime? ConsultationDate { get; private set; }

        internal bool IsSchedulingCompleted => TreatmentRoomId != null &&
                                                 DoctorId != null &&
                                                 ConsultationDate.HasValue;

        public void Apply(ConsultationSchedulingIsStartedEvent aggregateEvent)
        {
            PatientId = aggregateEvent.PatientId;
            PatientRegistrationDate = aggregateEvent.RegistrationDate;
        }

        public void Apply(Doctor.Events.DoctorIsReservedEvent aggregateEvent)
        {
            DoctorId = aggregateEvent.Id;
        }

        public void Apply(SchedulerHasReservedTreatmentRoom aggregateEvent)
        {
            TreatmentRoomId = aggregateEvent.TreatmentRoomId;
        }

        public void Apply(SchedulerHasReservedDoctorEvent aggregateEvent)
        {
            DoctorId = aggregateEvent.DoctorId;
            ConsultationDate = aggregateEvent.ReservationDay;
        }

        public void Apply(ConsultationSchedulingIsCompletedEvent aggregateEvent)
        {
        }
    }
}