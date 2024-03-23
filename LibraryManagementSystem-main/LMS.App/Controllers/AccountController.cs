using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using LMS.App.Models;
using LMS.Entities.Dtos;
using LMS.Entities.Models;
using LMS.Services.Contracts;
using LMS.Repositories.Contracts;

namespace LMS.App.Controllers
{
    public class AccountController : Controller
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IServiceManager _manager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AccountController(IRepositoryManager repositoryManager, IServiceManager manager, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _repositoryManager = repositoryManager;
            _manager = manager;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Login([FromQuery(Name = "url")] string ReturnUrl)
        {
            return View(new LoginModel()
            {
                ReturnUrl = ReturnUrl
            });
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromForm] LoginModel model)
        {
            if (model.IdentityNumber is null)
                ModelState.AddModelError("Error", "Lütfen TC kimlik numarasını girin.");
            if (model.Password is null)
                ModelState.AddModelError("Error", "Lütfen parolayı girin.");
            if (ModelState.IsValid)
            {
                ApplicationUser user = await _manager.ApplicationUserService.GetOneUserByUserName(model.IdentityNumber.ToString());
                if (user is not null)
                {
                    await _signInManager.SignOutAsync();
                    if ((await _signInManager.PasswordSignInAsync(user, model.Password, false, false)).Succeeded)
                    {
                        if (model.ReturnUrl.Equals("user"))
                            return RedirectToAction("Index", "Book");
                        else if(model.ReturnUrl.Equals("kargo"))
                            return RedirectToAction("Index", "Order", new { area = "Kargo" });
                        else if (model.ReturnUrl.Equals("personel"))
                            return RedirectToAction("Index", "NonOrder", new { area = "Personel" });
                        else if (model.ReturnUrl.Equals("admin"))
                            return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
                    }
                }
                ModelState.AddModelError("Error", "TC Kimlik veya Şifre geçersiz.");
            }
            return View(new LoginModel()
            
                
            );
        }
        public async Task<IActionResult> Logout([FromQuery(Name = "ReturnUrl")] string ReturnUrl = "/")
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Anasayfa","Home");
        }
        public IActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register([FromForm] RegisterDto model)
        {

            if (model.IdentityNumber is null)
                ModelState.AddModelError("Error", "Lütfen TC kimlik numarasını girin.");
            else if (!model.IdentityNumber.Count().Equals(11))
                ModelState.AddModelError("Error", "Lütfen 11 haneli bir TC kimilk numarası girin.");
            else
            {
                foreach (var item in model.IdentityNumber)
                {
                    if (item >= '0' && item <= '9')
                    {

                    }
                    else
                    {
                        ModelState.AddModelError("Error", "Lütfen geçerli bir TC kimlik numarası girin.");
                        break;
                    }
                }
            }
            if (model.FirstName is null)
                ModelState.AddModelError("Error", "Lütfen adı girin.");
            if (model.LastName is null)
                ModelState.AddModelError("Error", "Lütfen soyadı girin.");
            if (model.Email is null)
                ModelState.AddModelError("Error", "Lütfen e-maili girin.");
            if (model.Password is null)
                ModelState.AddModelError("Error", "Lütfen parolayı girin.");
            else if (model.Password.Length < 6)
                ModelState.AddModelError("Error", "Lütfen en az 6 haneli bir parola girin.");
            if (model.PhoneNumber is null)
                ModelState.AddModelError("Error", "Lütfen telefon numarasını girin.");
            else if (!model.PhoneNumber.Length.Equals(11))
                ModelState.AddModelError("Error", "Lütfen 11 haneli bir telefon numarası girin.");
            else
            {
                foreach (var item in model.PhoneNumber)
                {
                    if (item >= '0' && item <= '9')
                    {

                    }
                    else
                    {
                        ModelState.AddModelError("Error", "Lütfen geçerli bir telefon numarası girin.");
                        break;
                    }
                }
            }
            if (ModelState.IsValid)
            {
                var users = _manager.ApplicationUserService.GetAllUsers();
                foreach (var user in users)
                {
                    if (model.IdentityNumber.Equals(user.IdentityNumber))
                    {
                        ModelState.AddModelError("Error", "Bu TC kmilik numarası kullanılmaktadır. Lütfen başka bir TC kimlik numarası girin");
                        return View();
                    }
                }
                var result = await _manager.ApplicationUserService.CreateOneUser(model);
                if (result.Succeeded)
                    return RedirectToAction("Index","Home");
                else
                {
                    foreach (var err in result.Errors)
                        ModelState.AddModelError("Error", err.Description);
                }
            }
            return View();
        }
        public IActionResult AccessDenied([FromQuery(Name = "ReturnUrl")] string returnUrl)
        {
            return View();
        }
    }
}
