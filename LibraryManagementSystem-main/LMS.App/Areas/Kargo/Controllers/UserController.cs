using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LMS.Services.Contracts;
using LMS.Entities.RequestParameters;
using LMS.App.Models;
using LMS.Entities.Dtos;
using Microsoft.AspNetCore.Identity;
using LMS.Entities.Models;

namespace LMS.App.Areas.Kargo.Controllers
{
    [Area("Kargo")]
    [Authorize(Roles = "Kargo")]
    public class UserController : Controller
    {
        private readonly IServiceManager _manager;
        public UserController(IServiceManager manager)
        {
            _manager = manager;
        }
        public IActionResult Index([FromQuery] UserRequestParameter u)
        {
            ViewData["Title"] = "Kullanıcı";
            var users = _manager.ApplicationUserService.GetAllUsers();
            //var pagination = new Pagination()
            //{
            //    CurrentPage = u.PageNumber,
            //    ItemsPerPage = u.PageSize,
            //    TotalItems = users.Count()
            //};
            return View(new UserListViewModel()
            {
                Users = users
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
    }
}
