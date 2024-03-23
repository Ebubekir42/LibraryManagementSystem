using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Entities.Models
{
    public class NonOrder
    {
        public int NonOrderId { get; set; }
        public int LoanId { get; set; }
        public bool IsDeliver { get; set; } = false;
        public String? ApplicationUserId { get; set; }

    }
}
