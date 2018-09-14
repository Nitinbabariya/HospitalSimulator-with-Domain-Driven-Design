using EventFlow.Queries;
using Simulator.Domain.Patient;
using Simulator.Query.Patient;

namespace Simulator.Application.Client
{
    public sealed class PatientModel : ClientModelBase<PatientReadModel, PatientId>
    {

        public PatientModel(PatientId id, SimulatorClient client) : base(client, id) { }

        public PatientModel(PatientReadModel entity, SimulatorClient client) : base(client, new PatientId(entity.Id), entity)
        { }

        protected override PatientReadModel QueryReadModel()
        {
            return this.Query(new ReadModelByIdQuery<PatientReadModel>(this.Id));
        }
    }
}
