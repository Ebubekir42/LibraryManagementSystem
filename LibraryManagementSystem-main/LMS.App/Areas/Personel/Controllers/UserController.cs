using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LMS.Services.Contracts;
using LMS.Entities.RequestParameters;
using LMS.App.Models;
using LMS.Entities.Dtos;
using Microsoft.AspNetCore.Identity;
using LMS.Entities.Models;

namespace LMS.App.Areas.Personel.Controllers
{
    [Area("Personel")]
    [Authorize(Roles = "Personel")]
    public class UserController : Controller
    {

        public async Task<IActionResult> Index([FromQuery] UserRequestParameter u)
        {
            ViewData["Title"] = "Kullanıcı";
            var users = _manager.ApplicationUserService.GetAllUsers();
            List<ApplicationUser> _users = new List<ApplicationUser>();
            foreach (var user in users)
            {
                if ((await _userManager.GetRolesAsync(user))[0].Equals("User"))
                {
                    _users.Add(user);
                }
            }
            //var pagination = new Pagination()
            //{
            //    CurrentPage = u.PageNumber,
            //    ItemsPerPage = u.PageSize,
            //    TotalItems = users.Count()
            //};
            return View(new UserListViewModel()
            {
                Users = _users
            });
        }
        public IActionResult Create()
        {
            return View(new UserDtoForInsertion()
            {
                Roles = new HashSet<string>(_manager.ApplicationUserService.Roles.Select(r => r.Name).ToList())
            });
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] UserDtoForInsertion userDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _manager.ApplicationUserService.CreateOneUser(userDto);
                //return result.Succeeded ? RedirectToAction("Index") : View();
                if (result.Succeeded)
                {
                    if (userDto.Roles.FirstOrDefault().Equals("Personel"))
                    {
                        var personel = await _manager.ApplicationUserService.GetOneUserByUserName(userDto.IdentityNumber);
                        _manager.BookingOfficeService.CreateBookingOffice(new BookingOffice() { ApplicationUserId = personel.Id });
                    }
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            return View(new UserDtoForInsertion()
            {
                Roles = new HashSet<string>(_manager.ApplicationUserService.Roles.Select(r => r.Name).ToList())
            });
        }
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] string UserName)
        {
            var result = await _manager.ApplicationUserService.DeleteOneUser(UserName);
            return result.Succeeded ? RedirectToAction("Index") : View();
        }
        public async Task<IActionResult> Update()
        {
            var userName = User.Identity.Name;
            var user = await _manager.ApplicationUserService.GetOneUserByUserName(userName);
            return View(user);
        }
        private readonly IServiceManager _manager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        public UserController(IServiceManager manager, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _manager = manager;
            _roleManager = roleManager;
            _userManager = userManager;
        }
        

    }
}
