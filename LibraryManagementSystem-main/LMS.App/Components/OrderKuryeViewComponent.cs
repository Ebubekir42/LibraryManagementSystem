using Microsoft.AspNetCore.Mvc;
using LMS.Services.Contracts;

namespace LMS.App.Components
{
    public class OrderKuryeViewComponent : ViewComponent
    {
        private readonly IServiceManager _manager;
        public OrderKuryeViewComponent(IServiceManager manager)
        {
            _manager = manager;
        }
        public async Task<string> InvokeAsync(string id)
        {
            var user = await _manager.ApplicationUserService.GetOneUserByUserId(id);
            return user.FirstName + " " + user.LastName;
        }
    }
}
