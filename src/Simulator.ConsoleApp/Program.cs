using System;
using System.Threading;
using Simulator.Application;

namespace Simulator.ConsoleApp
{
   class Program
    {
        static void Main(string[] args)
        {
            //using (var client = SimulationApplication.Create().ConfigureFilesEventStore("c:\\SimulatorStore").Run())
            using (var client = SimulationApplication.Create().ConfigureInMemoryStore().Run())
            {
                var token = CancellationToken.None;

                client.SeedWithHistoricalEvents();

                var patient = client.RegisterCancerPatientWithHeadAndNeckTopography("PatientA");
                var patientB = client.RegisterCancerPatientWithBreastTopography("PatientB");
                var patientC = client.RegisterFluPatient("PatientC");

                var registeredPatients =  client.GetRegisteredPatients();
                var scheduleConsultations = client.GetScheduledConsultations();

                Console.WriteLine("\n\n\tExcellent!!");

            }

            Console.ReadKey();
        }
    }
}
