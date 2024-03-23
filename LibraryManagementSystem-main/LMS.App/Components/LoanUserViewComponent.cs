using Microsoft.AspNetCore.Mvc;
using LMS.Entities.Models;
using LMS.Services.Contracts;
using Microsoft.AspNetCore.Identity;

namespace LMS.App.Components
{
    public class LoanUserViewComponent : ViewComponent
    {
        private readonly IServiceManager _manager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;
        public LoanUserViewComponent(IServiceManager manager,RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _manager = manager;
            this.roleManager = roleManager;
            this.userManager = userManager;
        }
        public async Task<String> InvokeAsync(ApplicationUser user)
        {
            var roleName = (await userManager.GetRolesAsync(user))[0];
            if (roleName.Equals("User"))
            {
                var loans = _manager.LoanService.GetAllLoans(false);
                return loans.Where(x => x.ApplicationUserId.Equals(user.Id)).Count().ToString();
            }
            else
                return "";
        }
    }
}
