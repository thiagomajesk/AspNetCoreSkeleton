using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.App.Features.User.Commands;
using Project.App.Features.User.Queries;
using Project.Web.Constants;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Project.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMediator mediator;

        public HomeController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpGet("/error/{code?}")]
        public IActionResult Error(int? code)
        {
            if (code == null) return View();

            return View($"Errors/Error{code}");
        }

        [HttpGet]
        public IActionResult Denied()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(GetUserClaimsQuery query, string returnUrl)
        {
            var claims = await mediator.Send(query);

            if (claims.Any())
            {
                var principal = new ClaimsPrincipal(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme));

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return RedirectToAction(nameof(Index));
            }

            TempData[TempDataMessageTypes.Failure] = "Could not find user";

            return RedirectToAction(nameof(Error));
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction(nameof(Login));
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(CreateUserCommand command)
        {
            var user = await mediator.Send(command);

            if (user == null)
            {
                TempData[TempDataMessageTypes.Failure] = "Could not create user";
            }
            else
            {
                TempData[TempDataMessageTypes.Success] = "The user was created with success";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}