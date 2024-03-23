using LMS.Entities.Models;

namespace LMS.Repositories.Contracts
{
    public interface ILoanRepository
    {
        Loan GetLoan(int loanId, bool trackChanges);
        IQueryable<Loan> GetAllLoans(bool trackChanges);
        void CreateOneLoan(Loan loan);
    }
}
