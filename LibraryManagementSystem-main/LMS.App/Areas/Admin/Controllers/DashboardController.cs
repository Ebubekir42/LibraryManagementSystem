using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using LMS.Entities.Models;
using LMS.Repositories.Contracts;

namespace LMS.App.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IRepositoryManager _manager;
        public DashboardController(UserManager<ApplicationUser> userManager, IRepositoryManager manager)
        {
            _userManager = userManager;
            _manager = manager;
        }
        public IActionResult Index()
        {
            ViewData["Title"] = "Dashboard";
            //TempData["info"] = $"Tekrar Hoşgeldiniz";
            return View();
        }
    }
}
