using System.Threading;
using System.Threading.Tasks;
using EventFlow.Aggregates;
using EventFlow.Sagas;
using Simulator.Domain.ConsultationScheduler.Events;
using Simulator.Domain.Patient;
using Simulator.Domain.Patient.Events;

using DoctorIsReservedEvent = Simulator.Domain.Doctor.Events.DoctorIsReservedEvent;
using TreatmentRoomIsReservedEvent = Simulator.Domain.Treatmentroom.Events.TreatmentRoomIsReservedEvent;

namespace Simulator.Domain.ConsultationScheduler
{
    public sealed class ConsultationSchedulerSagaLocator : ISagaLocator
    {
        public ConsultationSchedulerSagaId GetSagaId(string patientId) => new ConsultationSchedulerSagaId(new PatientId(patientId));

        public ConsultationSchedulerSagaId GetSagaId(PatientId patientId) => new ConsultationSchedulerSagaId($"{ConsultationSchedulerSagaId.MetaKey}-{patientId}");

        public Task<ISagaId> LocateSagaAsync(IDomainEvent domainEvent, CancellationToken cancellationToken)
        {
            var @event = domainEvent.GetAggregateEvent();
            switch (@event)
            {
                case PatientIsRegisteredEvent _:
                {
                    var patientId = (PatientId)domainEvent.GetIdentity();
                    var sagaId = GetSagaId(patientId);
                    return Task.FromResult<ISagaId>(sagaId);
                }
                case TreatmentRoomIsReservedEvent treatmentRoomIsReserved:
                {
                    var sagaId = new ConsultationSchedulerSagaId(treatmentRoomIsReserved.ReferenceId);
                    return Task.FromResult<ISagaId>(sagaId);
                }
                case DoctorIsReservedEvent doctorIsReserved:
                {
                    var sagaId = new ConsultationSchedulerSagaId(doctorIsReserved.ReferenceId);
                    return Task.FromResult<ISagaId>(sagaId);
                }
                case ConsultationSchedulingIsCompletedEvent schedule:
                {
                    var sagaId = GetSagaId(schedule.PatientId);
                    return Task.FromResult<ISagaId>(sagaId);
                }
                default:
                {
                    var patientId = domainEvent.Metadata["patientId"];
                    var sagaId = GetSagaId(patientId);

                    return Task.FromResult<ISagaId>(sagaId);
                }
            }
        }
    }
}