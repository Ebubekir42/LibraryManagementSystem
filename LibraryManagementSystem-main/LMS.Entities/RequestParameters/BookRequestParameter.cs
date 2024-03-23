

namespace LMS.Entities.RequestParameters
{
    public class BookRequestParameter : RequestParameter
    {
        public int CategoryId { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public BookRequestParameter() : this(1, 12)
        {

        }
        public BookRequestParameter(int pageNumber = 1, int pageSize = 12)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
