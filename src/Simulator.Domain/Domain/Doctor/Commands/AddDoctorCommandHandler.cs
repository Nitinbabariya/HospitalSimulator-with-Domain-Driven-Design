using System.Threading;
using System.Threading.Tasks;
using EventFlow.Commands;

namespace Simulator.Domain.Doctor.Commands
{
    internal sealed class AddDoctorCommandHandler : CommandHandler<DoctorAggregate, DoctorId, AddDoctorCommand>
    {
        public override async Task ExecuteAsync(DoctorAggregate aggregate, AddDoctorCommand command, CancellationToken cancellationToken)
        {
            aggregate.Add(command.Name, command.Roles);
        }
    }
}