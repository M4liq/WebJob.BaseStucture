using Autofac;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.DependencyInjection
{
    public static class DependencyInjection
    {
        public static ContainerBuilder RegisterInfrastructure(this ContainerBuilder containerBuilder, IConfiguration configuration)
        {
            RegisterServices(containerBuilder);
            containerBuilder.InitializeConfiguration(configuration);

            return containerBuilder;
        }

        private static void RegisterServices(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterInstancePerLifetime<IServiceBase>();
        }
    }
}
