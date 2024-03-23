using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Entities.Dtos
{
    public record class BookDtoForDelete
    {
        public int ID { get; set; }
        public String? Title { get; set; }
        public int Page_No { get; set; }
        public String? ISBN_No { get; set; }
        public String? Yayin_Yeri { get; set; }
        public String? Yayinlayan { get; set; }
        public String? Yayin_Tarihi { get; set; }
        public String? Baski { get; set; }
        public int CategoryId { get; set; }
        public String? Copy { get; set; }
    }
}
