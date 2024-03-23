using LMS.Entities.Models;
using LMS.Services.Contracts;
using LMS.Repositories.Contracts;
using LMS.Entities.Dtos;
using AutoMapper;

namespace LMS.Services
{
    public class LoanManager : ILoanService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;
        public LoanManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }
        public Loan GetLoan(int loanId,bool trackChanges)
        {
            return _manager.Loan.GetLoan(loanId, trackChanges);
        }
        public IEnumerable<Loan> GetAllLoans(bool trackChanges)
        {
            return _manager.Loan.GetAllLoans(trackChanges);
        }
        public Loan IsInLibraryTheBookByBook(int bookId)
        {
            var loans = GetAllLoans(false).Where(l => l.BookId.Equals(bookId));
            foreach (var loan in loans)
            {
                if (loan.ReturnedDate is null)
                {
                    return loan;
                }
            }
            return null;
        }
        public int BookNumberOfLoanByBook(BookDtoForAddAsCopy bookDto)
        {
            var loans = _manager.Loan.GetAllLoans(false);
            int count = 0;
            foreach (var loan in loans)
            {
                var book = _manager.Book.GetOneBook(loan.BookId,false);
                var _bookDto = _mapper.Map<BookDtoForAddAsCopy>(book);
                if(_bookDto.Equals(bookDto))
                    count++;
            }
            return count;

        }
        public void CreateLoan(ApplicationUser user, Book book)
        {
            Loan loan = new Loan() { ApplicationUserId = user.Id, BookId = book.BookId };
            _manager.Loan.CreateOneLoan(loan);
            _manager.Save();
        }
        public void ReturnTheBook(int loanId)
        {
            var loan = _manager.Loan.GetLoan(loanId, true);
            var now_Date = DateTime.Now.ToString("dd/MM/yyyy");
            loan.ReturnedDate = now_Date;
            var old_date_List = loan.LoanDate.Split(".");
            DateTime? old_date = new DateTime(int.Parse(old_date_List[2]), int.Parse(old_date_List[1]), int.Parse(old_date_List[0]));
            var new_date_List = loan.ReturnedDate.Split(".");
            DateTime? new_date = new DateTime(int.Parse(new_date_List[2]), int.Parse(new_date_List[1]), int.Parse(new_date_List[0]));
            TimeSpan? gun_farki = new_date - old_date;
            if (gun_farki.Value.Days > 20 && gun_farki.Value.Days <= 30)
            {
                loan.ReturnedDate += " (" + (gun_farki.Value.Days - 20) + " gün geç iade ettiniz.)";
                var fine = _manager.Fine.GetFine(loan.ApplicationUserId, true);
                fine.Quantity += 10 * (gun_farki.Value.Days - 20);
            }
            _manager.Save();
        }
        public void LossTheBook(int loanId)
        {
            var loan = _manager.Loan.GetLoan(loanId, true);
            loan.ReturnedDate = "30 gün içinde iade etmediniz.";
            _manager.Save();
            
        }
        public void ControlTheLoans()
        {
            var loans = _manager.Loan.GetAllLoans(true);
            foreach (var loan in loans)
            {
                if (loan.ReturnedDate is null && loan.LoanDate is not null)
                {
                    var old_date_List = loan.LoanDate.Split(".");
                    DateTime? old_date = new DateTime(int.Parse(old_date_List[2]), int.Parse(old_date_List[1]), int.Parse(old_date_List[0]));
                    var nowDate = DateTime.Now.ToString("dd/MM/yyyy");
                    var new_date_List = nowDate.Split(".");
                    DateTime? new_date = new DateTime(int.Parse(new_date_List[2]), int.Parse(new_date_List[1]), int.Parse(new_date_List[0]));
                    TimeSpan? gun_farki = new_date - old_date;
                    if (gun_farki.Value.Days > 30)
                    {
                        loan.ReturnedDate = "30 gün içinde iade etmediniz.";
                        
                        _manager.Fine.AddQuantity(loan.ApplicationUserId, 200);
                        _manager.Book.LossTheBook(loan.BookId);
                    }
                }
            }
            _manager.Save();
        }

        public void CreateLoan(Loan loan)
        {
            _manager.Loan.CreateOneLoan(loan);
            _manager.Save();
        }
    }
}
