

namespace LMS.Entities.RequestParameters
{
    public class AuthorRequestParameter : RequestParameter
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public AuthorRequestParameter() : this(1, 12)
        {

        }
        public AuthorRequestParameter(int pageNumber = 1, int pageSize = 12)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

    }
}
