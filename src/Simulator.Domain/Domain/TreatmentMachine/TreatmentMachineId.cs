using EventFlow.Core;
using EventFlow.ValueObjects;
using Newtonsoft.Json;

namespace Simulator.Domain.TreatmentMachine
{
    [JsonConverter(typeof(SingleValueObjectConverter))]
    public sealed class TreatmentMachineId : Identity<TreatmentMachineId>
    {
        public TreatmentMachineId(string value) : base(value)
        {
        }
    }
}