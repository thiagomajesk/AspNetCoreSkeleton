using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.App.Features.Post.Commands;
using Project.App.Features.Post.Queries;
using System.Threading.Tasks;

namespace Project.Web.Controllers
{
    public class PostController : Controller
    {
        private readonly IMediator mediator;

        public PostController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await mediator.Send(new ListPostQuery { });

            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePostCommand command)
        {
            var result = await mediator.Send(command);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Show(ShowPostQuery query)
        {
            var result = await mediator.Send(query);

            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(EditPostQuery query)
        {
            var result = await mediator.Send(query);

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdatePostCommand command)
        {
            var result = await mediator.Send(command);

            return RedirectToAction(nameof(Index));
        }
    }
}