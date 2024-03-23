using Microsoft.AspNetCore.Mvc;
using LMS.Services.Contracts;
namespace LMS.App.Components
{
    public class BookingOfficeViewComponent : ViewComponent
    {
        private readonly IServiceManager _manager;
        public BookingOfficeViewComponent(IServiceManager manager)
        {
            _manager = manager;
        }
        public string Invoke(string perId)
        {
            return _manager.BookingOfficeService.GetBookingOfficeByPersonelId(perId, false).BookingOfficeId.ToString();
        }
    }
}
