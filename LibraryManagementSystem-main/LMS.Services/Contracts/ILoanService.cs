using LMS.Entities.Models;
using LMS.Entities.Dtos;

namespace LMS.Services.Contracts
{
    public interface ILoanService
    {
        Loan GetLoan(int loanId, bool trackChanges);
        IEnumerable<Loan> GetAllLoans(bool trackChanges);
        Loan IsInLibraryTheBookByBook(int bookId);
        int BookNumberOfLoanByBook(BookDtoForAddAsCopy bookDto);
        void CreateLoan(ApplicationUser user, Book book);
        void CreateLoan(Loan loan);
        void ReturnTheBook(int loanId);
        void LossTheBook(int  loanId);

        void ControlTheLoans();

    }
}
