using Microsoft.AspNetCore.Mvc;
using LMS.Services.Contracts;

namespace LMS.App.Components
{
    public class BookCaseViewComponent : ViewComponent
    {
        private readonly IServiceManager _manager;
        public BookCaseViewComponent(IServiceManager manager)
        {
            _manager = manager;
        }
        public string Invoke(int bookId)
        {
            var loan = _manager.LoanService.IsInLibraryTheBookByBook(bookId);
            if (loan is null)
                return "Rafta";
            else
                return "Rafta Değil";
        }
    }
}
