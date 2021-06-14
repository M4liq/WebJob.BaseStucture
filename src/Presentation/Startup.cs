using System.Threading.Tasks;
using Application;
using Application.Some;
using Autofac;
using Infrastructure.DependencyInjection;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace Presentation
{
    public class Startup
    {
        public IContainer Init() =>
            new ContainerBuilder()
                .RegisterInfrastructure(new ConfigurationBuilder().AddConfiguration().Build())
                .RegisterApplication()
                .Build();

        public async Task Run(IContainer container)
        {
             var mediator = container.BeginLifetimeScope().Resolve<IMediator>();

             mediator.Send(new SomeRequest());
        }
    }
}
