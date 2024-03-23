using LMS.Entities.Models;

namespace LMS.Entities.Models
{
    public class CarrierType
    {
        public int CarrierTypeId { get; set; }
        public string? CarrierName { get; set;}
        public int MediaTypeId { get; set; }
        public ICollection<Book>? Books{ get; set; }
    }
}
