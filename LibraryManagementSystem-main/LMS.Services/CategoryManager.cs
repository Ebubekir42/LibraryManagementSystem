using LMS.Entities.Models;
using LMS.Services.Contracts;
using LMS.Repositories.Contracts;
using LMS.Entities.Dtos;
using AutoMapper;

namespace LMS.Services
{
    public class CategoryManager : ICategoryService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;
        public CategoryManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }
        public void CreateOneCategory(CategoryDtoForInsertion categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            _manager.Category.CreateOneCategory(category);
            _manager.Save();
        }

        public void DeleteOneCategory(int id)
        {
            Category? category = GetOneCategory(id, false);
            if (category is not null)
            {
                _manager.Category.DeleteOneCategory(category);
                _manager.Save();
            }
        }

        public IEnumerable<Category> GetAllCategories(bool trackChanges)
        {
            return _manager.Category.GetAllCategories(trackChanges);
        }

        public Category GetOneCategory(int id, bool trackChanges)
        {
            Category? category = _manager.Category.GetOneCategory(id, trackChanges);
            if (category is null)
                throw new Exception("Category Not Found");
            return category;
        }

        public void UpdateOneCategory(CategoryDtoForUpdate categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            _manager.Category.UpdateOneCategory(category);
            _manager.Save();
        }
        public CategoryDtoForUpdate GetOneCategoryDtoForUpdate(int categoryId, bool trackChanges)
        {
            var category = _manager.Category.GetOneCategory(categoryId, trackChanges);
            var categoryDto = _mapper.Map<CategoryDtoForUpdate>(category);
            return categoryDto;
        }
    }
}
