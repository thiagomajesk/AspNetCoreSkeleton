using Project.App.Base.Queries;
using Project.App.Features.User.Commands;

namespace Project.App.Features.User.Queries
{
    public class EditUserQuery : IEditQuery<Domain.Entities.User, UpdateUserCommand>
    {
        public int Id { get; set; }
    }
}