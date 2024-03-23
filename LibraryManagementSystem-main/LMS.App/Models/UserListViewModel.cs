using LMS.Entities.Models;
namespace LMS.App.Models
{
    public class UserListViewModel
    {
        public IEnumerable<ApplicationUser> Users { get; set; } = Enumerable.Empty<ApplicationUser>();
        //public Pagination Pagination { get; set; } = new Pagination();
    }
}
