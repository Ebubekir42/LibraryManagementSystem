using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Entities.Models
{
    public class Format
    {
        public int FormatId { get; set; }
        public string? FormatName { get; set; }
        public ICollection<Book>? Books { get; set; }
    }
}
