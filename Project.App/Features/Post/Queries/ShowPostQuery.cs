using Project.App.Base.Queries;

namespace Project.App.Features.Post.Queries
{
    public class ShowPostQuery : IShowQuery<Domain.Entities.Post>
    {
        public int Id { get; set; }
    }
}