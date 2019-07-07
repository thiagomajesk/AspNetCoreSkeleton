using AutoMapper;
using Project.App.Base.Commands;

namespace Project.App.Features.Post.Commands
{
    [AutoMap(typeof(Domain.Entities.Post), ReverseMap = true)]
    public class UpdatePostCommand : PostForm, IUpdateCommand<Domain.Entities.Post>
    {
        public int Id { get; set; }
    }
}