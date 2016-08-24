using BootstrapProject.Web.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BootstrapProject.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly DatabaseContext context;

        public HomeController(DatabaseContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Página inicial da aplicação. Para onde o usuário é direcionado após o login
        /// </summary>
        /// <returns>Views/Home/Index</returns>
        [Authorize]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Retorno para teste de acesso negado. 
        /// Somente pode ser acessado caso o usuário tenha a 'Role' 'admin'
        /// </summary>
        /// <returns>Json com uma mensagem de confirmação</returns>
        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult Admin()
        {
            return Json("Ei! Você consegue visualizar isso porque é um administrador");
        }

        /// <summary>
        /// Página inicial com o formulário de login
        /// </summary>
        /// <returns>Views/Home/Login</returns>
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// Autentica o usuário na aplicação
        /// </summary>
        /// <param name="returnUrl">
        /// Url que o usuário estava tentando acessar quando foi 
        /// necessário realizar a autenticação. 
        /// Pode ser usada para retornar a navegação para o ponto de acesso
        /// </param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Login(string returnUrl)
        {
            string email = Request.Form["email"];
            string password = Request.Form["password"];

            var user = context.Users.SingleOrDefault(u =>
              u.Email.Equals(email, StringComparison.OrdinalIgnoreCase)
              && u.Password.Equals(password));

            if (user == null)
            {
                TempData["Error"] = "Não foi possível encontrar o usuário com o email e senha especificados";
                return RedirectToAction("Error");
            }

            var claims = new List<Claim> {
                new Claim(ClaimTypes.SerialNumber, user.Id.ToString(), ClaimValueTypes.Integer),
                new Claim(ClaimTypes.Email, user.Email, ClaimValueTypes.Email)
            };

            var principal = new ClaimsPrincipal(new ClaimsIdentity(claims, AuthenticationTypes.Password));

            await HttpContext.Authentication.SignInAsync("Cookie", principal);

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Desautentica o usuário da aplicação
        /// </summary>
        /// <returns>Redireciona para /home/login</returns>
        public async Task<IActionResult> Logout()
        {
            await HttpContext.Authentication.SignOutAsync("Cookie");

            return RedirectToAction("Login");
        }

        /// <summary>
        /// Página de erros.
        /// Destinada para exbidir os erros da aplicação
        /// </summary>
        /// <returns>Views/Shared/Error</returns>
        [HttpGet]
        public IActionResult Error()
        {
            return View();
        }

        /// <summary>
        /// Página de acesso negado.
        /// É invocada quando o usuário não tem as permissões necessárias 
        /// para acessar determinada action
        /// </summary>
        /// <returns>Views/Shared/Denied</returns>
        [HttpGet]
        public IActionResult Denied()
        {
            return View();
        }
    }
}