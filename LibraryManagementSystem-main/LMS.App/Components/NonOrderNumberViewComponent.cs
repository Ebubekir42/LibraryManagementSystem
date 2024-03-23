using Microsoft.AspNetCore.Mvc;
using LMS.Services.Contracts;
namespace LMS.App.Components
{
    public class NonOrderNumberViewComponent : ViewComponent
    {
        private readonly IServiceManager _manager;
        public NonOrderNumberViewComponent(IServiceManager manager)
        {
            _manager = manager;
        }
        public string Invoke()
        {
            return _manager.NonOrderService.GetAllNonOrders(false).Count().ToString();
        }
    }
}
