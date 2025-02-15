using Api.Data.Entities.Tables;
using Api.Infrastructure.Abstracts;
using Api.Service.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace Api.Service.Implementation
{
    public class CategoryService : ICategoryService
    {
        #region Fields
        private readonly ICategoryRepository _categoryRepository;
        #endregion
        #region Constructor
        public CategoryService(ICategoryRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;
        }


        #endregion
        #region HandleFunctions
        public async Task<string> AddCategoryAsync(string categoryName)
        {
            var dublicate = await _categoryRepository.GetTableNoTracking().Where(c => c.Name == categoryName).SingleOrDefaultAsync();
            if (dublicate != null)
            {
                return "NameIsExist";
            }
            var category = new Category { Name = categoryName };
            var res = await _categoryRepository.AddAsync(category);
            return "Success";
        }

        public async Task<string> DeleteCategoryAsync(int id)
        {
            var category = await _categoryRepository.GetTableNoTracking().Where(c => c.Id == id).SingleOrDefaultAsync();
            if (category == null)
            {
                return "CategoryIsNotExist";
            }
            await _categoryRepository.DeleteAsync(category);
            return "Success";
        }

        public async Task<string> EditCategoryAsync(Category category)
        {
            var tmp = await _categoryRepository.GetTableNoTracking().Where(c => c.Id == category.Id).SingleOrDefaultAsync();
            if (tmp == null)
            {
                return "CategoryIsNotExist";
            }
            await _categoryRepository.UpdateAsync(category);
            return "Success";
        }

        public async Task<List<Category>> GetCategoriesList()
        {
            return await _categoryRepository.GetTableNoTracking().ToListAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _categoryRepository.GetByIdAsync(id);
        }
        #endregion
    }
}
