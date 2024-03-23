

namespace LMS.Entities.Dtos
{
    public record BookDtoForUpdate
    {
        public int BookId { get; set; }
        public String? Title { get; set; }
        public int Page_No { get; set; }
        public String? ISBN_No { get; set; }
        public String? Yayin_Yeri { get; set; }
        public String? Yayinlayan { get; set; }
        public String? Yayin_Tarihi { get; set; }
        public String? Baski { get; set; }
        public String? Kopya { get; set; }
        public int CategoryId { get; set; }
        public List<int>? AuthorIds { get; set; }
        public List<int>? BookAuthorIds { get; set; }
        public String? Copyright_Date { get; set; }
        public String? Yayin_Gelis_Tarihi { get; set; }
        public String? Series { get; set; }
        public String? Notes { get; set; }
        public String? Summary { get; set; }
        public String? Subjects { get; set; }
        public String? Sorumlular { get; set; }
        public String? Fiziksel_Nitelik { get; set; }
        public int MediaTypeId { get; set; }
        public int CarrierTypeId { get; set; }
        public int ContentTypeId { get; set; }
        public int FormatId { get; set; }
        public int LanguageId { get; set; }
        public string? Room { get; set; }
        public String? Cabinet { get; set; }
        public String? Raf { get; set; }
    }
}
