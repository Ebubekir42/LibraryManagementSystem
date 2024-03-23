using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Entities.Models
{
    public class Receive
    {
        public int ReceiveId { get; set; }
        public int LoanId { get; set; }
        public String? ApplicationUserId { get; set; }
    }
}
