

namespace LMS.Entities.RequestParameters
{
    public class CategoryRequestParameter : RequestParameter
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public CategoryRequestParameter() : this(1, 12)
        {

        }
        public CategoryRequestParameter(int pageNumber = 1, int pageSize = 12)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
