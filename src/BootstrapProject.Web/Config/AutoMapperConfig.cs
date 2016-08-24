using AutoMapper;

namespace BootstrapProject.Web.Config
{
    /// <summary>
    /// Provider de configuracao dos profiles do automapper
    /// </summary>
    public static class AutoMapperConfig
    {
        public static Mapper MapperInstance => new Mapper(GetConfiguration());

        private static IConfigurationProvider GetConfiguration()
        {
            return new MapperConfiguration(config =>
            {
                config.AddProfile<ViewModelsMappingProfile>();
                config.AddProfile<UtilsMappingProfile>();
            });
        }
    }

    /// <summary>
    /// Profile com a definicao dos mapeamentos para os viewModels da aplicacao
    /// </summary>
    public class ViewModelsMappingProfile : Profile
    {
        public ViewModelsMappingProfile()
        {
            //CreateMap<TypeA, TypeB>();
        }
    }

    /// <summary>
    /// Profile com a definicao dos mapeamentos para as classes de utilidade da aplicacao
    /// </summary>
    public class UtilsMappingProfile : Profile
    {
        public UtilsMappingProfile()
        {
            //CreateMap<TypeA, TypeB>();
        }
    }
}
