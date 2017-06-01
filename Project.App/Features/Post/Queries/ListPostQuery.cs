using Project.App.Base.Queries;

namespace Project.App.Features.Post.Queries
{
    public class ListPostQuery : IListQuery<Domain.Entities.Post>
    {
        public string[] Includes { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}