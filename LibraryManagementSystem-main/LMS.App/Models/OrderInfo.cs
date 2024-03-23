using LMS.Entities.Models;
namespace LMS.App.Models
{
    public class OrderInfo
    {
        public int Id { get; set; }
        public String? FirstName { get; set; }
        public String? LastName { get; set;}
        public String? Email { get; set; }
        public String? PhoneNumber { get; set; }
        public Book? Book { get; set; }
        public String? Province { get; set; }
        public String? District { get; set; }
        public String? Address { get; set; }
        public String? KuryeId { get; set; }
        public String? OrderNo { get; set; }
    }
}
