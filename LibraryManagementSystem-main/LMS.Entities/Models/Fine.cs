    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Entities.Models
{
    public class Fine
    {
        public int FineId { get; set; }
        public int Quantity { get; set; } = 0;
        public string? ApplicationUserId { get; set; }
    }
}
