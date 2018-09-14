using EventFlow.Core;
using EventFlow.ValueObjects;
using Newtonsoft.Json;

namespace Simulator.Domain.Doctor
{
    [JsonConverter(typeof(SingleValueObjectConverter))]

    public sealed class DoctorId : Identity<DoctorId>
    {
        public DoctorId(string value) : base(value)
        {
        }
    }
}