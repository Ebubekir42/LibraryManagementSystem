using LMS.Entities.Models;

namespace LMS.App.Models
{
    public class CategoryBook
    {
        public Category? Category { get; set; }
        public IEnumerable<Book>? Books { get; set; }
    }
}
