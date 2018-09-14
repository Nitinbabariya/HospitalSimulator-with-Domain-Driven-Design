using EventFlow.Core;
using EventFlow.ValueObjects;

using Newtonsoft.Json;

namespace Simulator.Domain.Treatmentroom
{
    [JsonConverter(typeof(SingleValueObjectConverter))]
    public sealed class TreatmentRoomId : Identity<TreatmentRoomId>
    {
        public TreatmentRoomId(string value) : base(value)
        {
        }
    }
}