using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Entities.Models
{
    public class District
    {
        public int DistrictId { get; set; }
        public string? DistrictName { get; set;}
        public int ProvinceId { get; set; }
        public ICollection<Order>? Orders { get; set; }
    }
}
