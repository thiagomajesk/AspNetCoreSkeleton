using Project.App.Base.Commands;

namespace Project.App.Features.Post.Commands
{
    public class DeletePostCommand : IDeleteCommand<Domain.Entities.Post>
    {
        public int Id { get; set; }
    }
}