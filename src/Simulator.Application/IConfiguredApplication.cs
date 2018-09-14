using System;
using EventFlow;

namespace Simulator.Application
{
    public interface IConfiguredApplication
    {
        SimulationApplication Configure(Action<IEventFlowOptions> configuration);
        SimulatorClient Run();
    }
}