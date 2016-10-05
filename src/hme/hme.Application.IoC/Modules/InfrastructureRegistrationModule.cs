namespace hme.Application.IoC.Module
{
    using System.Reflection;
    using Autofac;
    using Infrastructure.Contracts;
    public class InfrastructureRegistrationModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            Assembly webRepositoriesProvidersAssembly = typeof(Infrastructure.Core.Repository).GetTypeInfo().Assembly;

            builder.RegisterAssemblyTypes(webRepositoriesProvidersAssembly)
                .AsImplementedInterfaces();

            builder.RegisterType<Infrastructure.Context.HMEMainBoundContextUnitOfWork>()                
                .As<IQueryableUnitOfWork>()
                .InstancePerRequest();

            base.Load(builder);
        }
    }
}
