using LMS.Entities.Models;
using LMS.App.Models;
namespace LMS.App.Models
{
    public class AnasayfaBook
    {
        public List<Book>? Books { get; set; }
        public List<BookOduncSayisi>? BookOduncSayisilar { get; set; }
    }
}
