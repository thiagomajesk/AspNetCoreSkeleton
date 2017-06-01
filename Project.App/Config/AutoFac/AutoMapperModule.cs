using Autofac;
using AutoMapper;

namespace Project.App.Config.AutoFac
{
    public class AutoMapperModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new MapperConfiguration(config => { config.AddProfiles(GetType().Assembly); }))
                .AsSelf().SingleInstance();

            builder.Register(c => c.Resolve<MapperConfiguration>().CreateMapper(c.Resolve)).As<IMapper>()
                .InstancePerLifetimeScope();
        }
    }
}