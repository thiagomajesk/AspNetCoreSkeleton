using Autofac;
using MediatR;

namespace Project.App.Config.AutoFac
{
    public class MediatRModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // MediatR
            builder.RegisterType<Mediator>().As<IMediator>().InstancePerLifetimeScope();

            // Request Handlers
            builder.Register<ServiceFactory>(context =>
            {
                var c = context.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            }).InstancePerLifetimeScope();

            // Application Handlers
            builder.RegisterAssemblyTypes(GetType().Assembly).AsImplementedInterfaces();
        }
    }
}