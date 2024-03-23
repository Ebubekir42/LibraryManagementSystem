using LMS.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace LMS.App.Components
{
    public class CategoryViewComponent : ViewComponent
    {
        private readonly IServiceManager _manager;
        public CategoryViewComponent(IServiceManager manager)
        {
            _manager = manager;
        }
        public string Invoke(int categoryId)
        {
            return _manager.CategoryService.GetOneCategory(categoryId, false).CategoryName;
        }
    }
}
