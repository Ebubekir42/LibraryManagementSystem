using LMS.Entities.Models;
namespace LMS.App.Models
{
    public class LoanListViewModel
    {
        public Loan? Loan { get; set; }
        public Book? Book { get; set; }
        public String? PerId { get; set; }
        public String? OrderNo { get; set; }
    }
}
