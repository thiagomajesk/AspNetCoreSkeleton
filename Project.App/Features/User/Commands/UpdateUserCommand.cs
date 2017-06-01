using Project.App.Base.Commands;

namespace Project.App.Features.User.Commands
{
    public class UpdateUserCommand : UserForm, IUpdateCommand<Domain.Entities.User>
    {
        public int Id { get; set; }
    }
}