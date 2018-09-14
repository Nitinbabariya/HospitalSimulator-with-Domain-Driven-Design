using System;
using System.Collections.Generic;
using System.Linq;

namespace Simulator.Query.TreatmentRoom
{
    public static class TreatmentRoomQueriesFactory
    {
        public static GetTreatmentRoomQuery RoomsEquippedWithAnyOfTheseMachines(IEnumerable<string> treatmentMachineIds)
            => new GetTreatmentRoomQuery(x => x.TreatmentMachineId != null && treatmentMachineIds.Contains(x.TreatmentMachineId.Value));
        public static GetTreatmentRoomQuery GetAllTreatmentRooms => new GetTreatmentRoomQuery(x =>true);
        public static GetTreatmentRoomQuery GetByTreatmentRoomId(string id)=> new GetTreatmentRoomQuery(x =>x.Id.Value.Equals(id,StringComparison.InvariantCultureIgnoreCase));
    }
}