using MediatR;
using Project.App.Features.User.Queries;
using Project.Infra;
using Project.Infra.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace Project.App.Features.User.Handlers
{
    public class FindUserByCredentialsQueryHandler : IRequestHandler<FindUserByCredentialsQuery, Domain.Entities.User>
    {
        private readonly DatabaseContext context;

        public FindUserByCredentialsQueryHandler(DatabaseContext context)
        {
            this.context = context;
        }

        public Task<Domain.Entities.User> Handle(FindUserByCredentialsQuery request, CancellationToken cancellationToken)
        {
            var user = context.Users.FindByCredentials(request.Email, request.Password);

            return Task.FromResult(user);
        }
    }
}