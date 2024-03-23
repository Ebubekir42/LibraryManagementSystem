using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Entities.RequestParameters
{
    public class UserRequestParameter : RequestParameter
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public UserRequestParameter() : this(1, 12)
        {

        }
        public UserRequestParameter(int pageNumber = 1, int pageSize = 12)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
