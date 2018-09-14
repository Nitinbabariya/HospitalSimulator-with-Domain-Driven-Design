using EventFlow.Aggregates;
using EventFlow.EventStores;

using Newtonsoft.Json;

using Simulator.Domain.Common;

namespace Simulator.Domain.Treatmentroom.Events
{
    [EventVersion("TreatmentRoomIsAddedEvent", 1)]
    public sealed class TreatmentRoomIsAddedEvent : AggregateEvent<TreatmentRoomAggregate, TreatmentRoomId>
    {
        public readonly Name Name;

        [JsonConstructor]
        public TreatmentRoomIsAddedEvent(Name name)
        {
            Name = name;
        }
    }
}