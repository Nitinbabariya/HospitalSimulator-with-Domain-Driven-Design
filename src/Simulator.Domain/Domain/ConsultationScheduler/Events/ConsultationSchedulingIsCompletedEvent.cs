using System;
using EventFlow.Aggregates;
using Simulator.Domain.Doctor;
using Simulator.Domain.Patient;
using Simulator.Domain.Treatmentroom;

namespace Simulator.Domain.ConsultationScheduler.Events
{
    public sealed class ConsultationSchedulingIsCompletedEvent : AggregateEvent<ConsultationSchedulerSaga, ConsultationSchedulerSagaId>
    {
        //TODO:Readonly or get only property
        public PatientId PatientId { get; private set; }
        public DoctorId DoctorId { get; private set; }
        public TreatmentRoomId TreatmentRoomId { get; private set; }
        public DateTime PatientRegistrationDate { get; private set; }
        public DateTime ConsultationDate { get; private set; }

        public ConsultationSchedulingIsCompletedEvent(PatientId patientId, DoctorId doctorId, TreatmentRoomId treatmentRoomId, DateTime patientRegistrationDate, DateTime consultationDate)
        {
            PatientId = patientId;
            DoctorId = doctorId;
            TreatmentRoomId = treatmentRoomId;
            PatientRegistrationDate = patientRegistrationDate;
            ConsultationDate = consultationDate;
        }
    }
}