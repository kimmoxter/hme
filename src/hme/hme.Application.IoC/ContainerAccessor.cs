using Autofac;

namespace hme.Application.IoC
{
    public static class ContainerAccessor
    {
        public static IContainer Container { get; set; }

        public static T Resolve<T>()
        {
            return Container.Resolve<T>();
        }

        public static T Resolve<T>(object value)
        {
            return Container.Resolve<T>(new TypedParameter(value.GetType(), value));
        }

        public static T ResolveKeyed<T>(object value)
        {
            return Container.ResolveKeyed<T>(value);
        }
    }
}
