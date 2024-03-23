using LMS.Entities.Models;

namespace LMS.Repositories.Contracts
{
    public interface ICategoryRepository : IRepostioryBase<Category>
    {
        IQueryable<Category> GetAllCategories(bool trackChanges);
        Category? GetOneCategory(int id, bool trackChanges);
        void CreateOneCategory(Category category);
        void UpdateOneCategory(Category category);
        void DeleteOneCategory(Category category);
    }
}
