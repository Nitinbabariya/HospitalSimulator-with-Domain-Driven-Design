using System.Threading;
using System.Threading.Tasks;

using EventFlow.Commands;

namespace Simulator.Domain.Patient.Commands
{
    internal sealed class RegisterCancerPatientWithBreastTopographyCommandHandler : CommandHandler<PatientAggregate, PatientId, RegisterCancerPatientWithBreastTopographyCommand>
    {
        public override async Task ExecuteAsync(PatientAggregate aggregate, RegisterCancerPatientWithBreastTopographyCommand command, CancellationToken cancellationToken)
        {
            aggregate.RegisterCancerPatientWithBreastTopography(command.Name);
        }
    }
}