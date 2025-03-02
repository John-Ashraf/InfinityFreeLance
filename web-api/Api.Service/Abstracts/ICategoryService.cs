using Api.Data.Entities.Tables;
using Microsoft.AspNetCore.Http;

namespace Api.Service.Abstracts
{
    public interface ICategoryService
    {
        Task<string> AddCategoryAsync(string categoryName, string CategoryNameAr, IFormFile Photo);
        Task<string> DeleteCategoryAsync(int id);
        Task<string> EditCategoryAsync(Category category, IFormFile Photo);
        Task<List<Category>> GetCategoriesList();
        Task<Category> GetCategoryByIdAsync(int id);

    }
}
