using System.Reflection;
using EventFlow;
using EventFlow.Extensions;

using Simulator.Domain.ConsultationScheduler;

namespace Simulator
{
    public static class Simulator
    {
        public static Assembly SimulatorAssembly => typeof(Simulator).GetTypeInfo().Assembly;

        public static IEventFlowOptions AddSimulatorDomain(this IEventFlowOptions options)
        {
            return options.AddDefaults(SimulatorAssembly);
        }
    }
}
