using LMS.Entities.Models;
namespace LMS.App.Models
{
    public class ReceiveLoanBook
    {
        public int LoanId { get; set; }
        public int ReceiveId { get; set; }
        public String? FirstName {  get; set; }
        public String? LastName { get; set; }
        public String? PhoneNumber { get; set; }
        public String? Email { get; set; }
        public Book? Book { get; set; }
        public String? PersonelId { get; set; }
    }
}
