using Microsoft.AspNetCore.Mvc;
using LMS.Services.Contracts;
namespace LMS.App.Components
{
    public class OrderNumberViewComponent
    {
        private readonly IServiceManager _manager;
        public OrderNumberViewComponent(IServiceManager manager)
        {
            _manager = manager;
        }
        public string Invoke()
        {
            return _manager.OrderService.GetAllOrders(false).Count().ToString();
        }
    }
}
