
namespace LMS.Entities.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        public String? FirstName { get; set; }
        public String? LastName { get; set; }
        public String? FullName => $"{FirstName} {LastName?.ToUpper()}";
        public ICollection<BookAuthor>? BookAuthors { get; set; } = new List<BookAuthor>();

    }
}
