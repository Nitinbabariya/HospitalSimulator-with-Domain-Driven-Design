using EventFlow.Core;
using EventFlow.ValueObjects;
using Newtonsoft.Json;

namespace Simulator.Domain.Patient
{
    [JsonConverter(typeof(SingleValueObjectConverter))]

    public sealed class PatientId : Identity<PatientId>
    {
        public PatientId(string value) : base(value)
        {
        }
    }
}