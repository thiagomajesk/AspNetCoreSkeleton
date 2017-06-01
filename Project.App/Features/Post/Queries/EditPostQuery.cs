using Project.App.Base.Queries;
using Project.App.Features.Post.Commands;

namespace Project.App.Features.Post.Queries
{
    public class EditPostQuery : PostForm, IEditQuery<Domain.Entities.Post, UpdatePostCommand>
    {
        public int Id { get; set; }
    }
}