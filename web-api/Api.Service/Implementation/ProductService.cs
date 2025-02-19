using Api.Data.Entities.Tables;
using Api.Infrastructure.Abstracts;
using Api.Service.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Api.Service.Implementation
{
    public class ProductService : IProductService
    {
        #region Fields
        private readonly IProductRepository _productRepository;
        private readonly IFileService _fileService;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        #endregion
        #region Constructor
        public ProductService(IProductRepository productRepository, IFileService fileService,
            IHttpContextAccessor httpContextAccessor, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _fileService = fileService;
            _httpContextAccessor = httpContextAccessor;
            _categoryRepository = categoryRepository;
        }




        #endregion
        #region HandleFunctions
        public async Task<Product> GetProductById(int productId)
        {
            return await _productRepository.GetTableNoTracking().Include(x => x.ProductCategory).Where(x => x.Id == productId).SingleOrDefaultAsync();
        }
        public async Task<string> AddproductAsync(Product product, List<IFormFile> files)
        {
            if (product.Price <= 0)
            {
                return "InvalidPrice";
            }
            var context = _httpContextAccessor.HttpContext.Request;
            var baseUrl = context.Scheme + "://" + context.Host;
            foreach (var photo in files)
            {
                var imageUrl = await _fileService.UploadImage("Products", photo);
                switch (imageUrl)
                {
                    case "NoImage": return "NoImage";
                    case "FailedToUploadImage": return "FailedToUploadImage";
                }
                product.Photos.Add(baseUrl + imageUrl);
            }

            try
            {
                _ = await _productRepository.AddAsync(product);
                return "Success";
            }
            catch (Exception ex)
            {
                return "FailedInAdd+ " + ex.Message;
            }
        }

        public async Task<string> DeleteProductById(int Id)
        {
            var prod = _productRepository.GetTableNoTracking().Where(x => x.Id == Id).FirstOrDefault();
            if (prod == null) return "NotFound";
            foreach (var photo in prod.Photos)
            {
                var res = await _fileService.DeleteImage("Products", photo);
                switch (res)
                {
                    case "FailedToDeleteImage": return "FailedToDeleteImage";
                    case "ImageNotFound": return "ImageNotFound";

                }

            }
            await _productRepository.DeleteAsync(prod);
            return "Success";
        }

        public async Task<List<Product>> GetAllProducts()
        {
            var result = _productRepository.GetTableNoTracking().Include(x => x.ProductCategory).ToList();
            return result;
        }

        public IQueryable<Product> GetQueryable()
        {
            return _productRepository.GetTableAsTracking().AsQueryable();
        }

        public async Task<string> EditProductAsync(Product product, List<IFormFile> files)
        {
            var context = _httpContextAccessor.HttpContext.Request;
            var baseUrl = context.Scheme + "://" + context.Host;

            foreach (var file in files)
            {
                var url = await _fileService.UploadImage("Products", file);
                switch (url)
                {
                    case "FailedToDeleteImage": return "FailedToDeleteImage";
                    case "ImageNotFound": return "ImageNotFound";

                }
                product.Photos.Add(baseUrl + url);
            }
            await _productRepository.UpdateAsync(product);
            return "Success";

        }
        #endregion
    }
}
