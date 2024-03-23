using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LMS.Services.Contracts;

namespace LMS.App.Areas.Kargo.Controllers
{
    [Area("Kargo")]
    [Authorize(Roles = "Kargo")]
    public class InfoController : Controller
    {
        private readonly IServiceManager _manager;
        public InfoController(IServiceManager manager)
        {
            _manager = manager;
        }
        public async Task<IActionResult> Index()
        {
            var userName = User.Identity.Name;
            var user = await _manager.ApplicationUserService.GetOneUserByUserName(userName);
            return View(user);
        }
        public IActionResult Update()
        {
            return View();
        }
    }
}
