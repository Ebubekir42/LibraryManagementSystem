using LMS.Entities.Models;
namespace LMS.App.Models
{
    public class BookInfo
    {
        public Book? Book { get; set; }
        public Category? Category { get; set; }
        public IEnumerable<Author>? Authors { get; set; }
    }
}
