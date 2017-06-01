using Project.App.Base.Commands;

namespace Project.App.Features.Post.Commands
{
    public class UpdatePostCommand : PostForm, IUpdateCommand<Domain.Entities.Post>
    {
        public int Id { get; set; }
    }
}