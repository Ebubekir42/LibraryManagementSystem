using Microsoft.AspNetCore.Mvc;
using LMS.Services.Contracts;
namespace LMS.App.Components
{
    public class BookDurumViewComponent : ViewComponent
    {
        private readonly IServiceManager _manager;
        public BookDurumViewComponent(IServiceManager manager)
        {
            _manager = manager;
        }
        public string Invoke(int bookId)
        {
            var loans = _manager.LoanService.GetAllLoans(false).Where(x => x.BookId.Equals(bookId));
 
            foreach(var loan in loans)
            {
                if(loan.ReturnedDate is null)
                {
                    return "Rafta Değil";
                }
            }
            return "Rafta";
        }
    }
}
