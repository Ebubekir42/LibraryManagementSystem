using LMS.Entities.Models;
namespace LMS.App.Models
{
    public class CategoryListViewModel
    {
        public List<Category> Categories { get; set; } = new List<Category>();        //public Pagination Pagination { get; set; } = new Pagination();
    }
}
