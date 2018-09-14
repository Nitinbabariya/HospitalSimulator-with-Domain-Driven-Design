using System.Threading;
using System.Threading.Tasks;
using EventFlow.Commands;
using EventFlow.Queries;

namespace Simulator.Domain.Doctor.Commands
{
    internal sealed class ReserveDoctorCommandHandler : CommandHandler<DoctorAggregate, DoctorId, ReserveDoctorCommand>
    {
        private readonly IQueryProcessor queryProcessor;

        public ReserveDoctorCommandHandler(IQueryProcessor queryProcessor)
        {
            this.queryProcessor = queryProcessor;
        }

        public override async Task ExecuteAsync(DoctorAggregate aggregate, ReserveDoctorCommand command,
            CancellationToken cancellationToken)
        {
            aggregate.ReserveDoctor(command.ReservationDay, command.ReferenceId);
        }
    }
}