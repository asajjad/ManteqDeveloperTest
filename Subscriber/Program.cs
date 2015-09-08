    using System;
    using Autofac;
    using ManteqCodeTest.Core;
    using NServiceBus;


class Program
{
    private static IContainer Container { get; set; }
    static void Main()
    {
        #region autofac

        ContainerBuilder builder = new ContainerBuilder();
        builder.RegisterGeneric(typeof(Repository<>))
              .As(typeof(IRepository<>));
        builder.RegisterType<EventStore>().As<IEventStore>();
        builder.RegisterType(typeof(ICommand));
        builder.RegisterType(typeof(IEvent));
        builder.RegisterType(typeof(IMessage));
        Container = builder.Build();

        #endregion autofac

        BusConfiguration busConfiguration = new BusConfiguration();
        busConfiguration.EndpointName("Samples.StepByStep.Subscriber");
        busConfiguration.UseSerialization<JsonSerializer>();
        busConfiguration.EnableInstallers();
        busConfiguration.UseContainer<AutofacBuilder>(c => c.ExistingLifetimeScope(Container));
        busConfiguration.UsePersistence<InMemoryPersistence>();

        using (IBus bus = Bus.Create(busConfiguration).Start())
        {
            Console.WriteLine("Press any key to exit subscriber");
            Console.ReadKey();
        }
    }
}