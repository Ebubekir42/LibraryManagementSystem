using LMS.Entities.Models;
using LMS.Repositories.Contracts;

namespace LMS.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateOneCategory(Category category) => Create(category);
        public void DeleteOneCategory(Category category) => Remove(category);
        public IQueryable<Category> GetAllCategories(bool trackChanges) => FindAll(trackChanges);
        public Category? GetOneCategory(int id, bool trackChanges)
        {
            return FindByCondition(c => c.CategoryId.Equals(id), trackChanges);
        }
        public void UpdateOneCategory(Category category) => Update(category);
    }
}
