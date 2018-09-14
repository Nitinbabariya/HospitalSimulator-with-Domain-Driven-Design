using Simulator.Domain.Common;

namespace Simulator.Domain.Patient.Events
{
    public sealed class FluPatientIsRegistered : PatientIsRegisteredEvent
    {
        public FluPatientIsRegistered(PatientId patientId, Name name) : base(patientId, name)
        {
        }
    }
}