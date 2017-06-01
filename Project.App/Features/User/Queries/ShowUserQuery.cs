using Project.App.Base.Queries;

namespace Project.App.Features.User.Queries
{
    public class ShowUserQuery : IShowQuery<Domain.Entities.User>
    {
        public int Id { get; set; }
    }
}