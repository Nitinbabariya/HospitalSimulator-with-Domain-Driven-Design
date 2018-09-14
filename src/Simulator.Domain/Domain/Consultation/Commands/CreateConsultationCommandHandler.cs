using System.Threading;
using System.Threading.Tasks;
using EventFlow.Commands;

namespace Simulator.Domain.Consultation.Commands
{
    internal sealed class CreateConsultationCommandHandler : CommandHandler<ConsultationAggregate, ConsultationId, CreateConsultationCommand>
    {
        public override async Task ExecuteAsync(ConsultationAggregate aggregate, CreateConsultationCommand command,
            CancellationToken cancellationToken)
        {
            aggregate.CreateConsultation(command.PatientId,command.DoctorId,command.TreatmentRoomId,command.RegistrationDate, command.ConsultationDate);
        }
    }
}