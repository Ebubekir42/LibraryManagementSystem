using LMS.Entities.Models;

namespace LMS.App.Models
{
    public class BookListViewModel
    {
        public IEnumerable<Book> Books { get; set; } = Enumerable.Empty<Book>();
        public IEnumerable<Loan> Loans { get; set; } = Enumerable.Empty<Loan>();
        public IEnumerable<Category> Categories { get; set; } = Enumerable.Empty<Category>();
        public IEnumerable<Language> Languages { get; set; } = Enumerable.Empty<Language>();
        public IEnumerable<Author> Authors { get; set; } = Enumerable.Empty<Author>();
        public IEnumerable<Format> Formats { get; set; } = Enumerable.Empty<Format>();
        public IEnumerable<String> YayinYeri { get; set; } = Enumerable.Empty<String>();
        public IEnumerable<String> Yayinlayan { get; set; } = Enumerable.Empty<String>();
        public IEnumerable<MediaType> MediaTypes{ get; set; } = Enumerable.Empty<MediaType>();
        public IEnumerable<CarrierType> CarrierTypes{ get; set; } = Enumerable.Empty<CarrierType>();
        public IEnumerable<ContentType> ContentTypes{ get; set; } = Enumerable.Empty<ContentType>();
        public String categoryId { get; set; } = null;
        public String languageId { get; set; } = null;
        public String  formatId { get; set; } = null;
        public String authorId { get; set; } = null;
        public String yayin_Yeri { get; set; } = null;
        public String yayin_layan { get; set; } = null;
        public String carrierTypeId { get; set; } = null;
        public String contentTypeId { get; set; } = null;
        public String mediaTypeId { get; set; } = null;
        public String filter { get; set; } = null;
        public String value { get; set; } = null;
        public Pagination Pagination { get; set; } = new Pagination();
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 12;
        public int TotalCount { get; set; }

    }
}
