using Project.App.Base.Commands;

namespace Project.App.Features.User.Commands
{
    public class CreateUserCommand : UserForm, ICreateCommand<Domain.Entities.User>
    {
    }
}