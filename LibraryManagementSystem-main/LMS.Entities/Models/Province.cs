using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Entities.Models
{
    public class Province
    {
        public int ProvinceId { get; set; }
        public string? Name { get; set; }
        public ICollection<District>? Districts { get; set; }
    }
}
