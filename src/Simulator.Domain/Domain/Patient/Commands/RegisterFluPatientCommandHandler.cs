using System.Threading;
using System.Threading.Tasks;

using EventFlow.Commands;

namespace Simulator.Domain.Patient.Commands
{
    internal sealed class RegisterFluPatientCommandHandler : CommandHandler<PatientAggregate, PatientId, RegisterFluPatientCommand>
    {
        public override async Task ExecuteAsync(PatientAggregate aggregate, RegisterFluPatientCommand command, CancellationToken cancellationToken)
        {
            aggregate.RegisterFluPatient(command.Name);
        }
    }
}