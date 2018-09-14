using Simulator.Domain.Common;

namespace Simulator.Domain.Patient.Events
{
    public sealed class CancerPatientWithHeadAndNeckTopygraphyIsRegistered : PatientIsRegisteredEvent
    {
        public CancerPatientWithHeadAndNeckTopygraphyIsRegistered(PatientId patientId, Name name) : base(patientId, name)
        {
        }
    }
}