using LMS.Entities.Models;
namespace LMS.App.Models
{
    public class OrderListViewModel
    {
        public int DistrictId { get; set; } = 1;
        public int ProvinceId { get; set; } = 1;
        public int BookId { get; set; }
        public int isOrder { get; set; }
        public String? FirstName { get; set; }
        public String? LastName { get; set; }
        public String? PhoneNumber { get; set; }
        public String? Email { get; set; }
        public Book? Book { get; set; }
    }
}
