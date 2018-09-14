using Simulator.Domain.Common;

namespace Simulator.Domain.Patient.Commands
{
    public sealed class RegisterFluPatientCommand: RegisterPatientCommand
    {
        public RegisterFluPatientCommand(PatientId aggregateId, Name name) : base(aggregateId, name)
        {
        }
    }
}