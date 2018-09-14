using System;
using EventFlow.Commands;
using Simulator.Domain.Doctor;
using Simulator.Domain.Patient;
using Simulator.Domain.Treatmentroom;

namespace Simulator.Domain.Consultation.Commands
{
    public sealed class CreateConsultationCommand : Command<ConsultationAggregate,ConsultationId>
    {
        public readonly PatientId PatientId;
        public readonly DoctorId DoctorId;
        public readonly TreatmentRoomId TreatmentRoomId;
        public readonly DateTime RegistrationDate;
        public readonly DateTime ConsultationDate;

        //TODO:Validate arguments
        public CreateConsultationCommand(ConsultationId aggregateId, PatientId patientId, DoctorId doctorId, TreatmentRoomId treatmentRoomId, DateTime registrationDate, DateTime consultationDate) : base(aggregateId)
        {
            PatientId = patientId;
            DoctorId = doctorId;
            TreatmentRoomId = treatmentRoomId;
            RegistrationDate = registrationDate;
            ConsultationDate = consultationDate;

        }
    }
}