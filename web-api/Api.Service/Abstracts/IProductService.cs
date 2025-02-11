using Api.Data.Entities.Tables;

namespace Api.Service.Abstracts
{
    public interface IProductService
    {
        Task<Product> GetProductById(int productId);
        Task<List<Product>> GetAllProducts();
        Task<Product> AddproductAsync(Product product);
        Task<string> DeleteProductById(int Id);
        IQueryable<Product> GetQueryable();
    }
}
