using MediatR;

namespace Project.App.Features.User.Queries
{
    public class FindUserByCredentialsQuery : IRequest<Domain.Entities.User>
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}