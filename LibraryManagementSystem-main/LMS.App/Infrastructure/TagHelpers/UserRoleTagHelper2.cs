using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.TagHelpers;
using LMS.Entities.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LMS.App.Infrastructure.TagHelpers
{
    [HtmlTargetElement("tr", Attributes = "user-role")]
    public class UserRoleTagHelper2 : TagHelper
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        [HtmlAttributeName("user-name")]
        public ApplicationUser? User { get; set; }
        public UserRoleTagHelper2(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var user = await _userManager.FindByNameAsync(User.UserName);
            var roles = _roleManager.Roles.ToList().Select(r => r.Name);
            TagBuilder td = new TagBuilder("td");
            td.Attributes.Add("class", "text-muted small");
            td.InnerHtml.AppendHtml("Rol");
            TagBuilder td2 = new TagBuilder("td");
            foreach (var role in roles)
            {
                if (await _userManager.IsInRoleAsync(user, role))
                {
                    td2.InnerHtml.AppendHtml(role.ToString());
                    break;
                }
            }
            output.Content.AppendHtml(td);
            output.Content.AppendHtml(td2);
        }
    }
}
