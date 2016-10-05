using System.Reflection;
using Autofac;
using hme.Domain.Services;

namespace hme.Application.IoC.Module
{
    public class DomainRegistrationModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            Assembly assembly = typeof(IDomainService).Assembly;
            
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces();
                        
            base.Load(builder);
        }
    }
}
