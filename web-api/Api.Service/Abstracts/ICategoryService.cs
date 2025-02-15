using Api.Data.Entities.Tables;

namespace Api.Service.Abstracts
{
    public interface ICategoryService
    {
        Task<string> AddCategoryAsync(string categoryName);
        Task<string> DeleteCategoryAsync(int id);
        Task<string> EditCategoryAsync(Category category);
        Task<List<Category>> GetCategoriesList();
        Task<Category> GetCategoryByIdAsync(int id);

    }
}
