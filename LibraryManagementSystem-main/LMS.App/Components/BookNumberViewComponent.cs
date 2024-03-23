using LMS.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace LMS.App.Components
{
    public class BookNumberViewComponent : ViewComponent
    {
        private readonly IServiceManager _manager;
        public BookNumberViewComponent(IServiceManager manager)
        {
            _manager = manager;
        }
        public string Invoke()
        {
            return _manager.BookService.GetAllBooks(false).Where(x => x.isLoss == false).Count().ToString();
        }
    }
}
