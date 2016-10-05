namespace hme.Application.IoC
{
    using Autofac;    
    using Module;
    public static class AutofacConfig
    {
        public static ContainerBuilder Builder { get; set; }

        public static void ConfigContainer()
        {
            Builder = new ContainerBuilder();

            Builder.RegisterModule<InfrastructureRegistrationModule>();
            Builder.RegisterModule<ApplicationRegistrationModule>();
            Builder.RegisterModule<DomainRegistrationModule>();
        }

        public static void BuildContainer()
        {
            IContainer container = Builder.Build();

            ContainerAccessor.Container = container;
        }
    }
}
