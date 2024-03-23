using LMS.Entities.Models;

namespace LMS.App.Models
{
    public class AuthorBook
    {
        public IEnumerable<Book>? Books { get; set; }
        public Author? Author { get; set; }
    }
}
