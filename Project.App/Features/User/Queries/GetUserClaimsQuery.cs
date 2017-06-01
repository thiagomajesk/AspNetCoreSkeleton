using MediatR;
using System.Collections.Generic;
using System.Security.Claims;

namespace Project.App.Features.User.Queries
{
    public class GetUserClaimsQuery : IRequest<List<Claim>>
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}