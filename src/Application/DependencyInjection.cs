using Application.Some;
using Autofac;
using MediatR;

namespace Application
{
    public static class DependencyInjection
    {

        public static ContainerBuilder RegisterApplication(this ContainerBuilder containerBuilder)
        {
            RegisterMediator(containerBuilder);
            RegisterRequestHandlers(containerBuilder);
            return containerBuilder;
        }

        private static void RegisterMediator(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<Mediator>().As<IMediator>().InstancePerLifetimeScope();

            containerBuilder.Register<ServiceFactory>(context =>
            {
                var c = context.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });
        }

        private static void RegisterRequestHandlers(ContainerBuilder containerBuilder)
        {
            void Register<T>() => containerBuilder.RegisterType<T>().AsImplementedInterfaces().InstancePerDependency();
            Register<SomeRequestHandler>();
        }
    }
}