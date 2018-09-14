using Simulator.Domain.Common;

namespace Simulator.Domain.Patient.Commands
{
    public sealed class RegisterCancerPatientWithBreastTopographyCommand : RegisterPatientCommand
    {
        public RegisterCancerPatientWithBreastTopographyCommand(PatientId aggregateId, Name name) : base(aggregateId, name)
        {
        }
    }
}