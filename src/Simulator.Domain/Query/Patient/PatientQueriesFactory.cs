namespace Simulator.Query.Patient
{
    public static class PatientQueriesFactory
    {
        public static GetPatientsQuery GetPatientByIdQuery(string patientId) => new GetPatientsQuery(x => x.Id == patientId);
        public static GetPatientsQuery GetAllRegisteredPatientsQuery => new GetPatientsQuery(x =>true);
    }
}