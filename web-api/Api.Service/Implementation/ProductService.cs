using Api.Data.Entities.Tables;
using Api.Infrastructure.Abstracts;
using Api.Service.Abstracts;

namespace Api.Service.Implementation
{
    public class ProductService : IProductService
    {
        #region Fields
        private readonly IProductRepository _productRepository;
        #endregion
        #region Constructor
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }




        #endregion
        #region HandleFunctions
        public async Task<Product> GetProductById(int productId)
        {
            return await _productRepository.GetByIdAsync(productId);
        }
        public async Task<Product> AddproductAsync(Product product)
        {
            return await _productRepository.AddAsync(product);
        }

        public async Task<string> DeleteProductById(int Id)
        {
            var prod = _productRepository.GetTableNoTracking().Where(x => x.Id == Id).FirstOrDefault();
            if (prod == null) return "NotFound";
            await _productRepository.DeleteAsync(prod);
            return "Success";

        }

        public async Task<List<Product>> GetAllProducts()
        {
            var result = _productRepository.GetTableNoTracking().ToList();
            return result;
        }

        public IQueryable<Product> GetQueryable()
        {
            return _productRepository.GetTableAsTracking().AsQueryable();
        }
        #endregion
    }
}
