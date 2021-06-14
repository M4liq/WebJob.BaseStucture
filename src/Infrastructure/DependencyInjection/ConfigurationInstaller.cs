using System;
using System.IO;
using Autofac;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.DependencyInjection
{
    public static class ConfigurationInstaller
    {
        public static ContainerBuilder InitializeConfiguration(this ContainerBuilder containerBuilder, IConfiguration configuration)
        {
            RegisterSettings(containerBuilder, configuration);
            return containerBuilder;
        }

        public static IConfigurationBuilder AddConfiguration(this ConfigurationBuilder configurationBuilder) =>
            configurationBuilder
                .SetBasePath(Path.Combine(AppContext.BaseDirectory))
                .AddJsonFile("appsettings.json", true, true);


        public static ContainerBuilder RegisterSettings(ContainerBuilder containerBuilder, IConfiguration configuration)
        {
            //containerBuilder.Register(_ => configuration.GetSection("SomeSection").Get<SomeSectionSettings>())
            //    .As<ISomeSectionSettings>().SingleInstance();

            return containerBuilder;
        }
    }
}
