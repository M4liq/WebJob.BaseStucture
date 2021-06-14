using System.Reflection;
using Autofac;

namespace Infrastructure.DependencyInjection
{
    public static class DependencyInjectionExtensions
    {
        public static ContainerBuilder RegisterInstancePerLifetime<T>(this ContainerBuilder containerBuilder)
        {
            foreach (var assemblyName in Assembly.GetExecutingAssembly().GetReferencedAssemblies())
            {
                var assembly = Assembly.Load(assemblyName);

                containerBuilder.RegisterAssemblyTypes(assembly)
                    .AssignableTo<T>()
                    .AsImplementedInterfaces()
                    .InstancePerLifetimeScope();
            }

            return containerBuilder;
        }
    }
}
