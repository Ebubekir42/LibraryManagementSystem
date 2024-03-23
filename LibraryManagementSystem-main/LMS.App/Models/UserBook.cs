using LMS.Entities.Models;
namespace LMS.App.Models
{
    public class UserBook
    {
        public BookListViewModel? Model { get; set; }
        public ApplicationUser? User { get; set; }
    }
}
