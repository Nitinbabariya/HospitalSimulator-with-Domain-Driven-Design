using System;
using System.Linq;

using Simulator.Domain.Doctor;

namespace Simulator.Query.Doctor
{
    public static class DoctorQueriesFactory{
        public static GetDoctorsQuery GetById(string doctorId)=> new GetDoctorsQuery(x => x.Id.Equals(doctorId,StringComparison.InvariantCultureIgnoreCase));
        public static GetDoctorsQuery GetAllOncologists => new GetDoctorsQuery(x => x.Roles.Contains(Role.Oncologist));
        public static GetDoctorsQuery GetAllGeneralPractitioners => new GetDoctorsQuery(x => x.Roles.Contains(Role.GeneralPractitioner));
    }
}