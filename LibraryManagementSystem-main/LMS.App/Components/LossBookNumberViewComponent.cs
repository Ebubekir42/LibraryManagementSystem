using Microsoft.AspNetCore.Mvc;
using LMS.Services.Contracts;
namespace LMS.App.Components
{
    public class LossBookNumberViewComponent
    {
        private readonly IServiceManager _manager;
        public LossBookNumberViewComponent(IServiceManager manager)
        {
            _manager = manager;
        }
        public string Invoke()
        {
            return _manager.BookService.GetAllBooks(false).Where(x => x.isLoss == true).Count().ToString();
        }
    }
}
