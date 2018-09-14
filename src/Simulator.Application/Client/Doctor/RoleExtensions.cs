using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Simulator.Application.Client.Doctor
{
    public static class RoleExtensions
    {
        public static ImmutableList<Domain.Doctor.Role> ToDomain(this IEnumerable<Role> roles)
        {
            return roles.Select(x => (Domain.Doctor.Role)x).ToImmutableList();
        }

        public static ImmutableList<Role> ToModel(this IEnumerable<Domain.Doctor.Role> roles)
        {
            return roles.Select(x => (Role)x).ToImmutableList();
        }
    }
}