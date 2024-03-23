using Microsoft.AspNetCore.Mvc;
using LMS.Services.Contracts;
using AutoMapper;
using LMS.Entities.Dtos;

namespace LMS.App.Components
{
    public class BookLoanViewComponent : ViewComponent
    {
        public readonly IServiceManager _manager;
        public readonly IMapper _mapper;
        public BookLoanViewComponent(IServiceManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }
        public string Invoke(int bookId)
        {
            var book = _manager.BookService.GetOneBook(bookId, false);
            return _manager.LoanService.GetAllLoans(false).Where(x => x.BookId.Equals(bookId)).Count().ToString();
            //var bookDto = _mapper.Map<BookDtoForAddAsCopy>(book);
            //return _manager.LoanService.BookNumberOfLoanByBook(bookDto).ToString();
        }
    }
}
