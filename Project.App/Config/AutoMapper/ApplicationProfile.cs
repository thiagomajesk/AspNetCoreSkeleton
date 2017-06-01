using AutoMapper;
using Project.App.Features.Post.Commands;
using Project.App.Features.Post.Queries;
using Project.App.Features.User.Commands;
using Project.App.Features.User.Queries;

namespace Project.App.Config.AutoMapper
{
    public class ApplicationMappings : Profile
    {
        public ApplicationMappings()
        {
            CreateMap<CreateUserCommand, Domain.Entities.User>().ReverseMap();
            CreateMap<DeleteUserCommand, Domain.Entities.User>().ReverseMap();
            CreateMap<ListUserQuery, Domain.Entities.User>().ReverseMap();
            CreateMap<UpdateUserCommand, Domain.Entities.User>().ReverseMap();

            CreateMap<CreatePostCommand, Domain.Entities.Post>().ReverseMap();
            CreateMap<DeletePostCommand, Domain.Entities.User>().ReverseMap();
            CreateMap<ListPostQuery, Domain.Entities.User>().ReverseMap();
            CreateMap<UpdatePostCommand, Domain.Entities.User>().ReverseMap();
        }
    }
}