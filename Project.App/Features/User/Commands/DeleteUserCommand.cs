using Project.App.Base.Commands;

namespace Project.App.Features.User.Commands
{
    public class DeleteUserCommand : IDeleteCommand<Domain.Entities.User>
    {
        public int Id { get; set; }
    }
}