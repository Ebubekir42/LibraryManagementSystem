using Microsoft.AspNetCore.Mvc;
using LMS.Services.Contracts;
namespace LMS.App.Components
{
    public class PersonelInfoViewComponent : ViewComponent
    {
        private readonly IServiceManager _manager;
        public PersonelInfoViewComponent(IServiceManager manager)
        {
            _manager = manager;
        }
        public async Task<string> InvokeAsync(string perId)
        {
            var per = await _manager.ApplicationUserService.GetOneUserByUserId(perId);
            if(per is null)
                return null;
            return per.FirstName + " " + per.LastName;
        }
    }
}
