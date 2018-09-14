using System.Collections.Generic;
using System.Collections.Immutable;

using EventFlow.Commands;
using Simulator.Domain.Common;

namespace Simulator.Domain.Doctor.Commands
{
    public sealed class AddDoctorCommand:Command<DoctorAggregate,DoctorId>
    {
        public readonly Name Name;
        public readonly ImmutableList<Role> Roles;

        //TODO:Validate command
        public AddDoctorCommand(DoctorId aggregateId, Name name, ImmutableList<Role> role) : base(aggregateId)
        {
            Name = name;
            Roles = role;
        }
    }
}