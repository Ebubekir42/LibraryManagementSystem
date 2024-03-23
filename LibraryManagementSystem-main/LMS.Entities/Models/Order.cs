using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Entities.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string? Address { get; set; }
        public int LoanId { get; set; }
        public int DistrictId { get; set; }
        public bool IsDeliver { get; set; } = false;
        public String? OrderNo { get; set; }
        public String? ApplicationUserId { get; set; }
    }
}
