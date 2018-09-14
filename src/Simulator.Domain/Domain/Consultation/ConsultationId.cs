using EventFlow.Core;
using EventFlow.ValueObjects;
using Newtonsoft.Json;

namespace Simulator.Domain.Consultation
{
    [JsonConverter(typeof(SingleValueObjectConverter))]

    public sealed class ConsultationId : Identity<ConsultationId>
    {
        public ConsultationId(string value) : base(value)
        {
        }
    }
}