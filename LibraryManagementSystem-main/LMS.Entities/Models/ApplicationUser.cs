using Microsoft.AspNetCore.Identity;

namespace LMS.Entities.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? IdentityNumber { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Password { get; set; }
        public ICollection<Loan>? Loans { get; set; }
        public ICollection<Fine>? Fine { get; set; }
        public ICollection<Order>? Orders { get; set; }
        public ICollection<NonOrder>? NonOrders { get; set; }
        public ICollection<BookingOffice>? BookingOffices { get; set; }
        public ICollection<Receive> Receives { get; set; }
    }
}
