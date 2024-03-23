using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Entities.Dtos
{
    public record OrderDtoForInsertion
    {
        public string? Address { get; set; }
        public int DistrictId { get; set; }
        public int ProvinceId { get; set; }
        public int BookId { get; set; }
        public int isOrder { get; set; }
    }
}
