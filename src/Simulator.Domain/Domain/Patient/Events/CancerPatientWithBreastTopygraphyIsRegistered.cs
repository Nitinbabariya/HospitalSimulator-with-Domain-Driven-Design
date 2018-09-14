using Simulator.Domain.Common;

namespace Simulator.Domain.Patient.Events
{
    public sealed class CancerPatientWithBreastTopygraphyIsRegistered : PatientIsRegisteredEvent
    {
        public CancerPatientWithBreastTopygraphyIsRegistered(PatientId patientId, Name name) : base(patientId, name)
        {
        }
    }
}