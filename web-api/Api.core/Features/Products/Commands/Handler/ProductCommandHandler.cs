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
                            IRequestHandler<DeleteProductCommand, Response<string>>
    {
        #region Fields
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        #endregion
        #region Constructors
        public ProductCommandHandler(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }



        #endregion
        #region Function Handler
        public async Task<Response<string>> Handle(AddproductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product { Name = request.Name, Photos = request.Photos, Description = request.Description, Price = request.Price };
            _ = await _productService.AddproductAsync(product);
            return Created("");

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

        #endregion
    }
}
