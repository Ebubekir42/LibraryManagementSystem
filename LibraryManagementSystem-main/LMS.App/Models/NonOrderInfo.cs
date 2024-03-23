using LMS.Entities.Models;
namespace LMS.App.Models
{
    public class NonOrderInfo
    {
        public int Id { get; set; }
        public String? FirstName { get; set; }
        public String? LastName { get; set; }
        public String? Email { get; set; }
        public String? PhoneNumber { get; set; }
        public Book? Book { get; set; }
        public String? PersonelId { get; set; }
    }
}
