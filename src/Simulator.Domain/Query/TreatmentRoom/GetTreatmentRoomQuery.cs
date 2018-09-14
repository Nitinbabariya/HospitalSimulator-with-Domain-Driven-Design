using System;
using System.Collections.Generic;

using EventFlow.Queries;

using Simulator.Domain.Common;
using Simulator.Query.TreatmentRoom;

namespace Simulator.Query.TreatmentRoom
{
    public sealed class GetTreatmentRoomQuery : IQuery<IReadOnlyCollection<TreatmentRoomReadModel>>
    {
        public readonly Predicate<TreatmentRoomReadModel> Predicate;
        public GetTreatmentRoomQuery(Predicate<TreatmentRoomReadModel> predicate)
        {
            Predicate = predicate;
        }
    }
}
