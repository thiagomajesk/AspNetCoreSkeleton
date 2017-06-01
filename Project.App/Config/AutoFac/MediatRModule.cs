using Autofac;
using MediatR;
using System.Collections.Generic;

namespace Project.App.Config.AutoFac
{
    public class MediatRModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // MediatR
            builder.RegisterType<Mediator>().As<IMediator>().InstancePerLifetimeScope();

            // Request Handlers
            builder.Register<SingleInstanceFactory>(ctx =>
            {
                var c = ctx.Resolve<IComponentContext>();
                return t =>
                {
                    object o;
                    return c.TryResolve(t, out o) ? o : null;
                };
            }).InstancePerLifetimeScope();

            // Notification Handlers
            builder.Register<MultiInstanceFactory>(ctx =>
            {
                var c = ctx.Resolve<IComponentContext>();
                return t => (IEnumerable<object>)c.Resolve(typeof(IEnumerable<>).MakeGenericType(t));
            }).InstancePerLifetimeScope();

            // Application Handlers
            builder.RegisterAssemblyTypes(GetType().Assembly).AsImplementedInterfaces();
        }
    }
}