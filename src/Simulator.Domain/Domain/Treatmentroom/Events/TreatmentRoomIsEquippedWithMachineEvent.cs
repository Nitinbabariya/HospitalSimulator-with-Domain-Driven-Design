using EventFlow.Aggregates;
using EventFlow.EventStores;

using Newtonsoft.Json;

using Simulator.Domain.TreatmentMachine;

namespace Simulator.Domain.Treatmentroom.Events
{
    [EventVersion("TreatmentRoomIsEquippedWithMachineEvent", 1)]
    public sealed class TreatmentRoomIsEquippedWithMachineEvent : AggregateEvent<TreatmentRoomAggregate, TreatmentRoomId>
    {
        public readonly TreatmentMachineId TreatmentMachineId;

        [JsonConstructor]
        public TreatmentRoomIsEquippedWithMachineEvent(TreatmentMachineId treatmentMachineId)
        {
            TreatmentMachineId = treatmentMachineId;
        }
    }
}