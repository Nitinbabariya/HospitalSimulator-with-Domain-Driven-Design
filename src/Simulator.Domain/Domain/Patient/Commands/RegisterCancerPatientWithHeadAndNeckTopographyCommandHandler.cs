using System.Threading;
using System.Threading.Tasks;

using EventFlow.Commands;

namespace Simulator.Domain.Patient.Commands
{
    internal sealed class RegisterCancerPatientWithHeadAndNeckTopographyCommandHandler : CommandHandler<PatientAggregate, PatientId, RegisterCancerPatientWithHeadAndNeckTopographyCommand>
    {
        public override async Task ExecuteAsync(PatientAggregate aggregate, RegisterCancerPatientWithHeadAndNeckTopographyCommand command, CancellationToken cancellationToken)
        {
            aggregate.RegisterCancerPatientWithHeadAndNeckTopography(command.Name);
        }
    }
}