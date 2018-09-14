using Simulator.Domain.Common;

namespace Simulator.Domain.Patient.Commands
{
    public sealed class RegisterCancerPatientWithHeadAndNeckTopographyCommand : RegisterPatientCommand
    {
        public RegisterCancerPatientWithHeadAndNeckTopographyCommand(PatientId aggregateId, Name name) : base(aggregateId, name)
        {
        }
    }
}