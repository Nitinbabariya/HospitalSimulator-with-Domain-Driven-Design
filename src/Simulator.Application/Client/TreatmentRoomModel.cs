using EventFlow.Queries;

using Simulator.Domain.Treatmentroom;
using Simulator.Query.TreatmentRoom;

namespace Simulator.Application.Client
{
    public sealed class TreatmentRoomModel : ClientModelBase<TreatmentRoomReadModel, TreatmentRoomId>
    {
        public TreatmentRoomModel(TreatmentRoomId id, SimulatorClient client) : base(client, id)
        {
        }

        public TreatmentRoomModel(TreatmentRoomReadModel readModel, SimulatorClient client) : base(client, new TreatmentRoomId(readModel.Id.Value), readModel)
        {
        }

        protected override TreatmentRoomReadModel QueryReadModel()
        {
            return this.Query(new ReadModelByIdQuery<TreatmentRoomReadModel>(this.Id));
        }

        public string TreatmentMachineId => this.ReadModel.TreatmentMachineId.Value;

    }
}
