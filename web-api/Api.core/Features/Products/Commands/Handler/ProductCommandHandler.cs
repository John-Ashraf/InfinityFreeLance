using Api.Core.Bases;
using Api.Core.Features.Products.Commands.Models;
using Api.Data.Entities.Tables;
using Api.Service.Abstracts;
using AutoMapper;
using MediatR;

namespace Api.Core.Features.Products.Commands.Handler
{
    public class ProductCommandHandler : ResponseHandler,
                            IRequestHandler<AddproductCommand, Response<string>>,
                            IRequestHandler<DeleteProductCommand, Response<string>>,
                            IRequestHandler<EditProductCommand, Response<string>>
    {
        #region Fields
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        #endregion
        #region Constructors
        public ProductCommandHandler(IProductService productService, IMapper mapper, ICategoryService categoryService)
        {
            _productService = productService;
            _mapper = mapper;
            _categoryService = categoryService;
        }



        #endregion
        #region Function Handler
        public async Task<Response<string>> Handle(AddproductCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryService.GetCategoryByIdAsync(request.Catid);
            if (category == null) { return NotFound<string>("CategoryNotFound"); }

            var product = new Product { Name = request.Name, Photos = new List<string>(), Description = request.Description, Price = request.Price, ProductCategory = category, NameAr = request.NameAr };
            var res = await _productService.AddproductAsync(product, request.Photos);
            if (res == "Success")
            {
                return Created("Success");
            }
            else
            {
                return BadRequest<string>(res);
            }


        }

        public async Task<Response<string>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var response = await _productService.DeleteProductById(request.id);
            if (response == "NotFound")
            {
                return NotFound<string>(response);
            }
            return Success(response);
        }

        public async Task<Response<string>> Handle(EditProductCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryService.GetCategoryByIdAsync(request.CategoryId);
            if (category == null) { return NotFound<string>("InVaidCategoryId"); }
            var Product = new Product { Id = request.Id, Name = request.Name, Price = request.Price, ProductCategory = category, Description = request.Description, NameAr = request.NameAr };
            var res = await _productService.EditProductAsync(Product, request.Photos);
            if (res == "Success")
            {
                return Success(res);
            }
            else
            {
                return BadRequest<string>(res);
            }
        }

        #endregion
    }
}
