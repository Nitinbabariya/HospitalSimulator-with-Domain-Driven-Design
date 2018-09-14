using System;

using Autofac;

using EventFlow;
using EventFlow.Autofac.Extensions;
using EventFlow.EventStores.Files;
using EventFlow.Extensions;

using Simulator.Query.Consultation;
using Simulator.Query.Doctor;
using Simulator.Query.Patient;
using Simulator.Query.TreatmentMachine;
using Simulator.Query.TreatmentRoom;

namespace Simulator.Application
{
    public sealed class SimulationApplication : IConfiguredApplication
    {
        private IEventFlowOptions options;
        private readonly Lazy<IContainer> container;

        private SimulationApplication()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<SimulatorClient>().AsSelf();
            builder.RegisterAssemblyTypes(Simulator.SimulatorAssembly)
                   .Where(t => t.Name.EndsWith("Service"))
                   .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(this.GetType().Assembly)
                   .Where(t => t.Name.EndsWith("Service"))
                   .AsImplementedInterfaces();

            this.options = EventFlowOptions.New
                                           .UseAutofacContainerBuilder(builder)
                                           .AddSimulatorDomain();

            this.container = new Lazy<IContainer>(() => this.options.CreateContainer());
        }

        public SimulationApplication Configure(Action<IEventFlowOptions> configuration)
        {
            configuration(this.options);
            return this;
        }

        public IConfiguredApplication ConfigureInMemoryStore()
        {
            this.UseInMemoryStore();
            return this;
        }

        public IConfiguredApplication ConfigureFilesEventStore(string storePath)
        {
            this.UseFileSystemBasedStore(storePath);
            return this;
        }

        public SimulatorClient Run()
        {
            return this.container.Value.Resolve<SimulatorClient>();
        }

        public static SimulationApplication Create()
        {
            return new SimulationApplication();
        }

        private void UseInMemoryStore()
        {
            this.options
                .AddQueryHandlers(Simulator.SimulatorAssembly)
                .UseInMemoryReadStoreFor<TreatmentRoomReadModel>()
                .UseInMemoryReadStoreFor<TreatmentMachineReadModel>()
                .UseInMemoryReadStoreFor<DoctorReadModel>()
                .UseInMemoryReadStoreFor<PatientReadModel>()
                .UseInMemoryReadStoreFor<ConsultationReadModel>();
        }

        private void UseFileSystemBasedStore(string storePath)
        {
            var fileEventStoreConfiguration = FilesEventStoreConfiguration.Create(storePath);
            this.options.UseFilesEventStore(fileEventStoreConfiguration)
                .AddQueryHandlers(Simulator.SimulatorAssembly)
                .UseInMemoryReadStoreFor<TreatmentRoomReadModel> ()
                .UseInMemoryReadStoreFor<TreatmentMachineReadModel>()
                .UseInMemoryReadStoreFor<DoctorReadModel>()
                .UseInMemoryReadStoreFor<PatientReadModel>()
                .UseInMemoryReadStoreFor<ConsultationReadModel>();
        }


        //public static IEventFlowOptions UseFileSystemStoreFor<TReadModel>(IEventFlowOptions eventFlowOptions)
        //    where TReadModel: class, IReadModel, new()
        //{
        //    return eventFlowOptions
        //        .RegisterServices(f =>
        //        {
        //            f.Register<ISearchableReadModelStore<TReadModel>, LiteDbReadModelStore<TReadModel>>();
        //            f.Register<IReadModelStore<TReadModel>>(r =>
        //                r.Resolver
        //                 .Resolve<ISearchableReadModelStore<TReadModel>>());
        //        })
        //        .UseReadStoreFor<ISearchableReadModelStore<TReadModel>, TReadModel>();
        //}
    }
}