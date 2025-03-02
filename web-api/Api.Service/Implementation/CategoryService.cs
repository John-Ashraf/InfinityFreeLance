using Api.Data.Entities.Tables;
using Api.Infrastructure.Abstracts;
using Api.Service.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Api.Service.Implementation
{
    public class CategoryService : ICategoryService
    {
        #region Fields
        private readonly ICategoryRepository _categoryRepository;
        private readonly IFileService _fileService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        #endregion
        #region Constructor
        public CategoryService(ICategoryRepository categoryRepository, IFileService fileService, IHttpContextAccessor httpContextAccessor)
        {
            this._categoryRepository = categoryRepository;
            _fileService = fileService;
            _httpContextAccessor = httpContextAccessor;
        }


        #endregion
        #region HandleFunctions
        public async Task<string> AddCategoryAsync(string categoryName, string CategoryNameAr, IFormFile Photo)
        {
            var dublicate = await _categoryRepository.GetTableNoTracking().Where(c => c.Name == categoryName).SingleOrDefaultAsync();
            if (dublicate != null)
            {
                return "NameIsExist";
            }
            var context = _httpContextAccessor.HttpContext.Request;
            var baseUrl = context.Scheme + "://" + context.Host;
            var url = _fileService.UploadImage("Category", Photo);
            var category = new Category { Name = categoryName, Photo = baseUrl + url.Result, NameAr = CategoryNameAr };
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

        public async Task<string> EditCategoryAsync(Category category, IFormFile photo)
        {
            var tmp = await _categoryRepository.GetTableNoTracking().Where(c => c.Id == category.Id).SingleOrDefaultAsync();
            if (tmp == null)
            {
                return "CategoryIsNotExist";
            }
            var context = _httpContextAccessor.HttpContext.Request;
            var baseUrl = context.Scheme + "://" + context.Host;
            var url = _fileService.UploadImage("Category", photo);
            tmp.Photo = baseUrl + url.Result;
            tmp.Name = category.Name;
            tmp.NameAr = category.NameAr;
            await _categoryRepository.UpdateAsync(tmp);
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
