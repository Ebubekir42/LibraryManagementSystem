using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.TagHelpers;
using LMS.Entities.Models;

namespace LMS.App.Infrastructure.TagHelpers
{
    [HtmlTargetElement("td",Attributes = "user-role")]
    public class UserRoleTagHelper : TagHelper
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        [HtmlAttributeName("user-name")]
        public ApplicationUser? User { get; set; }
        public UserRoleTagHelper(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var user = await _userManager.FindByNameAsync(User.UserName);
            var roles = _roleManager.Roles.ToList().Select(r => r.Name);
            foreach(var role in roles)
            {
                if(await _userManager.IsInRoleAsync(user, role))
                {
                    output.Content.AppendHtml(role.ToString());
                    break;
                }
            }
        }
    }
}
