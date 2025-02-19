using Api.Data.Entities.Tables;
using Microsoft.AspNetCore.Http;

namespace Api.Service.Abstracts
{
    public interface IProductService
    {
        Task<Product> GetProductById(int productId);
        Task<List<Product>> GetAllProducts();
        Task<string> AddproductAsync(Product product, List<IFormFile> files);
        Task<string> DeleteProductById(int Id);
        IQueryable<Product> GetQueryable();
        Task<string> EditProductAsync(Product product, List<IFormFile> files);
    }
}
