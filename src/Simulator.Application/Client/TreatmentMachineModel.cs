using EventFlow.Queries;
using Simulator.Domain.TreatmentMachine;
using Simulator.Query.TreatmentMachine;

namespace Simulator.Application.Client
{
    public sealed class TreatmentMachineModel : ClientModelBase<TreatmentMachineReadModel, TreatmentMachineId>
    {
        public TreatmentMachineModel(TreatmentMachineId id, SimulatorClient client) : base(client, id)
        {
        }

        public TreatmentMachineModel(TreatmentMachineReadModel entity, SimulatorClient client) : base(client, new TreatmentMachineId(entity.Id))
        {
        }

        protected override TreatmentMachineReadModel QueryReadModel()
        {
            return this.Query(new ReadModelByIdQuery<TreatmentMachineReadModel>(this.Id));
        }

        public bool HasAdvancedCapability => this.ReadModel.HasAdvancedCapability;
        public bool HasSimpleCapability => this.ReadModel.HasSimpleCapability;
    }
}