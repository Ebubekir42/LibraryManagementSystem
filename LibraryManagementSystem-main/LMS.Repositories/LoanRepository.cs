using LMS.Entities.Models;
using LMS.Repositories.Contracts;

namespace LMS.Repositories
{
    public class LoanRepository : RepositoryBase<Loan>, ILoanRepository
    {
        public LoanRepository(RepositoryContext context) : base(context)
        {
        }
        public Loan? GetLoan(int loanId, bool trackChanges)
        {
            return FindByCondition(l => l.LoanId.Equals(loanId), trackChanges);
        }
        public IQueryable<Loan> GetAllLoans(bool trackChanges) => FindAll(trackChanges);
        public void CreateOneLoan(Loan loan) => Create(loan);
    }
}
