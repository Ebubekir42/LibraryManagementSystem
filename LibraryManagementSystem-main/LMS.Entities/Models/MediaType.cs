using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Entities.Models
{
    public class MediaType
    {
        public int MediaTypeId { get; set; }
        public string? MediaName { get; set; }
        public ICollection<CarrierType> CarrierTypes{ get; set; }
    }
}
