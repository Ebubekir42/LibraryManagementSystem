using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.Entities.Models
{
    public class Loan
    {
        public int LoanId { get; set; }
        public String? LoanDate { get; set; }
        public String? LastReturnDate { get; set; }
        public String? ReturnedDate { get; set; } 
        public string? ApplicationUserId { get; set; }
        public int BookId { get; set; }
        public bool IsOrder { get; set; }
        public ICollection<Order>? Orders { get; set; }
        public ICollection<NonOrder>? NonOrders { get; set; }
        public ICollection<Receive> Receives { get; set; }
    }
}
