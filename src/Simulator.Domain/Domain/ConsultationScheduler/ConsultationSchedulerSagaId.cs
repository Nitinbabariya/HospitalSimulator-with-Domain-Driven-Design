using EventFlow.Sagas;
using EventFlow.ValueObjects;
using Simulator.Domain.Patient;

namespace Simulator.Domain.ConsultationScheduler
{
    public sealed class ConsultationSchedulerSagaId : ValueObject, ISagaId
    {
        public readonly PatientId PatientId;
        public static readonly string MetaKey = "ConsultationSchedulerId";

        public ConsultationSchedulerSagaId(PatientId patientId)
        {
            PatientId = patientId;
        }

        public ConsultationSchedulerSagaId(string value)
        {
            //TODO:Use compiled regex instead of string.Replace(..)
            var id = value.Replace($"{MetaKey}-", "");

            this.PatientId = new PatientId(id);
        }

        public string Value => $"{MetaKey}-"+ this.PatientId.Value;
    }
}