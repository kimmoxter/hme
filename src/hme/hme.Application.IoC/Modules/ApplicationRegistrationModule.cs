using Autofac;
using AutoMapper;
using hme.Application.Adapter;
using System.Reflection;

namespace hme.Application.IoC.Module
{
    public class ApplicationRegistrationModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            Assembly applicationServiceProvidersAssembly = typeof(Application.Providers.ApplicationService).GetTypeInfo().Assembly;

            builder.RegisterAssemblyTypes(applicationServiceProvidersAssembly).AsImplementedInterfaces();

            builder.Register(ctx => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new Profiles.ApplicationAdapterProfile());
            }));

            builder.Register(ctx => ctx.Resolve<MapperConfiguration>().CreateMapper()).As<IMapper>().PropertiesAutowired();

            builder.RegisterType<TypeAdapter>()
                .As<ITypeAdapter>()
                .WithParameter(
                (pi, ctx) => pi.ParameterType == typeof(IMapper),
                (pi, ctx) => ctx.Resolve<IMapper>());

            base.Load(builder);
        }
    }
}