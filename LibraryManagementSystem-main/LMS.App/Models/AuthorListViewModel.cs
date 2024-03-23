using LMS.Entities.Models;
namespace LMS.App.Models
{
    public class AuthorListViewModel
    {
        public IEnumerable<Author> Authors { get; set; } = Enumerable.Empty<Author>();
        //public Pagination Pagination { get; set; } = new Pagination();
    }
}
