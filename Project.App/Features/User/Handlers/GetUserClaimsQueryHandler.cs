using MediatR;
using Project.App.Features.User.Queries;
using Project.Infra;
using Project.Infra.Queries;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace Project.App.Features.User.Handlers
{
    public class GetUserClaimsQueryHandler : IRequestHandler<GetUserClaimsQuery, List<Claim>>
    {
        private readonly DatabaseContext context;

        public GetUserClaimsQueryHandler(DatabaseContext context)
        {
            this.context = context;
        }

        public Task<List<Claim>> Handle(GetUserClaimsQuery request, CancellationToken cancellationToken)
        {
            var user = context.Users.FindByCredentials(request.Email, request.Password);

            if (user == null) return Task.FromResult(new List<Claim>());

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.SerialNumber, user.Id.ToString(), ClaimValueTypes.Integer),
                new Claim(ClaimTypes.Email, user.Email, ClaimValueTypes.Email)
            };

            return Task.FromResult(claims);
        }
    }
}