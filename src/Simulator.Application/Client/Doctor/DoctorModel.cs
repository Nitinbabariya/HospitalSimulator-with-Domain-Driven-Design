using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

using EventFlow.Queries;

using Simulator.Domain.Doctor;
using Simulator.Query.Doctor;

namespace Simulator.Application.Client.Doctor
{
    public sealed class DoctorModel : ClientModelBase<DoctorReadModel, DoctorId>
    {
        public DoctorModel(DoctorId id, SimulatorClient client) : base(client, id) { }

        public DoctorModel(DoctorReadModel entity, SimulatorClient client) : base(client, new DoctorId(entity.Id),entity)
        { }

        protected override DoctorReadModel QueryReadModel()
        {
            return this.Query(new ReadModelByIdQuery<DoctorReadModel>(this.Id));
        }

        public string Name => this.ReadModel.Name;
        public ImmutableList<Role> Roles => this.ReadModel.Roles.ToModel();
    }
}