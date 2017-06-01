using Project.App.Base.Commands;

namespace Project.App.Features.Post.Commands
{
    public class CreatePostCommand : PostForm, ICreateCommand<Domain.Entities.Post>
    {
        public int AuthorId { get; set; }
    }
}