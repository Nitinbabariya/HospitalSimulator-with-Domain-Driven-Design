namespace Simulator.Query.TreatmentMachine
{
    public static class TreatmentMachineQueriesFactory
    {
        public static GetTreatmentMachinesQuery GetWithAdvanceCapability => new GetTreatmentMachinesQuery(x => x.HasAdvancedCapability);
        public static GetTreatmentMachinesQuery GetRoomsWithAdvanceOrSimpleCapability => new GetTreatmentMachinesQuery(x => x.HasAdvancedCapability || x.HasSimpleCapability);
        public static GetTreatmentMachinesQuery GetAllMachines => new GetTreatmentMachinesQuery(x =>true);
        public static GetTreatmentMachineByNameQuery GetMachineByName (string name) => new GetTreatmentMachineByNameQuery(name);
    }
}