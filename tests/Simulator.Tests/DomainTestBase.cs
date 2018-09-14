using System;
using System.IO;
using Simulator.Application;
using Xunit.Abstractions;

namespace Simulator.Tests
{
    public abstract class DomainTestBase : IDisposable
    {
        private readonly ITestOutputHelper _output;
        protected readonly SimulatorClient Client;

        protected DomainTestBase(ITestOutputHelper output)
        {
            _output = output;
            this.Client = SimulationApplication.Create().ConfigureInMemoryStore().Run();
        }

        public void Dispose()
        {
            this.Client.Dispose();
        }
    }
}