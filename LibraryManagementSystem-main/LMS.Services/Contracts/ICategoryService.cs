using LMS.Entities.Models;
using LMS.Entities.Dtos;

namespace LMS.Services.Contracts
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAllCategories(bool trackChanges);
        Category GetOneCategory(int id, bool trackChanges);
        void CreateOneCategory(CategoryDtoForInsertion categoryDto);
        void UpdateOneCategory(CategoryDtoForUpdate categoryDto);
        void DeleteOneCategory(int id);
        CategoryDtoForUpdate GetOneCategoryDtoForUpdate(int categoryId, bool trackChanges);

    }
}
