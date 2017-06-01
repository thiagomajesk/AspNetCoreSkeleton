using Project.App.Base.Queries;

namespace Project.App.Features.User.Queries
{
    public class ListUserQuery : IListQuery<Domain.Entities.User>
    {
        public string[] Includes { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}