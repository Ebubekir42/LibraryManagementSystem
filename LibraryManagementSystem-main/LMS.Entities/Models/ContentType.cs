using LMS.Entities.Models;

namespace LMS.Entities.Models
{
    public class ContentType
    {
        public int ContentTypeId { get; set; }
        public string? ContentName { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
