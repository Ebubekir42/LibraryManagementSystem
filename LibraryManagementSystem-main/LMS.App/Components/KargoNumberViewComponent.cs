using LMS.Services.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using LMS.Entities.Models;
namespace LMS.App.Components
{
    public class KargoNumberViewComponent
    {
        private readonly IServiceManager _manager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        public KargoNumberViewComponent(UserManager<ApplicationUser> userManager, IServiceManager manager, RoleManager<IdentityRole> roleManager)
        {
            _manager = manager;
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public async Task<string> InvokeAsync()
        {
            var users = _manager.ApplicationUserService.GetAllUsers();
            var count = 0;
            foreach (var user in users)
            {
                if ((await _userManager.GetRolesAsync(user))[0].Equals("Kargo"))
                {
                    count++;

                }
            }
            return count.ToString();
        }
    }
}
