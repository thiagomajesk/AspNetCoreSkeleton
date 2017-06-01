using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Project.Web.ViewComponents
{
    public class VersionViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string prefix)
        {
            return View(null, $"{prefix} - {Environment.Version}");
        }
    }
}