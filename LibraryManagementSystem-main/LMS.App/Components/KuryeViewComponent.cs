using Microsoft.AspNetCore.Mvc;
using LMS.Services.Contracts;
namespace LMS.App.Components
{
    public class KuryeViewComponent : ViewComponent
    {
        private readonly IServiceManager _manager;
        public KuryeViewComponent(IServiceManager manager)
        {
            _manager = manager;
        }
        public async Task<string> InvokeAsync()
        {
            var kuryeName = User.Identity.Name;
            var kurye = await _manager.ApplicationUserService.GetOneUserByUserName(kuryeName);
            return kurye.Id;
        }
    }
}
