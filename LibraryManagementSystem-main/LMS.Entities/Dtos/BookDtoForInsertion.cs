using LMS.Entities.Models;

namespace LMS.Entities.Dtos
{
    public record BookDtoForInsertion
    {
        public String? Title { get; set; }
        public String? ISBN_No { get; set; }
        public String? Resim { get; set; }
        public String? Yayin_Yeri { get; set; }
        public String? Yayinlayan { get; set; }
        public String? Yayin_Tarihi { get; set; }
        public String? Yayın_Gelis_Tarihi { get; set; }
        public String? CopyRightDate { get; set; }
        public String? Notes { get; set; }
        public String? Summary { get; set; }
        public String? Konular { get; set; }
        public String? Fiziksel_Nitelik { get; set; }
        public String? Baski { get; set; }
        public String? Sorumlular { get; set; }
        public int MediaTypeId { get; set; }
        public int CarrierTypeId { get; set; }
        public int ContentTypeId { get; set; }
        public int CategoryId { get; set; }
        public int LanguageId { get; set; }
        public int FormatId { get; set; }
        public int Oda { get; set; }
        public int Dolap { get; set; }
        public int Raf { get; set; }
        public List<int>? AuthorIds { get; set; }
        public String? Kopya;
    }
}
