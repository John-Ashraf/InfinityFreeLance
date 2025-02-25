using Api.Core.Bases;
using Api.Core.Features.Products.Queries.Models;
using Api.Core.Features.Products.Queries.Response;
using Api.Data.Entities.Tables;
using Api.Service.Abstracts;
using AutoMapper;
using MediatR;
using School.Core.Wrappers;

namespace Api.Core.Features.Products.Queries.Handler
{ //IRequestHandler<GetPaginatedListQuery, PaginatedResult<GetUserListResponse>>

    public class ProductQueriesHandler : ResponseHandler
                                    , IRequestHandler<GetProductByIdQuery, Response<GetProductByIdResponse>>
                                    , IRequestHandler<GetAllProductsQuery, Response<List<GetProductByIdResponse>>>
                                    , IRequestHandler<GetPaginatedProductsQuery, PaginatedResult<GetProductByIdResponse>>
                                    , IRequestHandler<GetProductsByCategory, Response<List<GetProductByIdResponse>>>

    {
        #region Fields
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        #endregion
        #region Constructors
        public ProductQueriesHandler(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }


        #endregion
        #region Function Handler
        public async Task<Response<List<GetProductByIdResponse>>> Handle(GetProductsByCategory request, CancellationToken cancellationToken)
        {
            var Products = await _productService.GetProductsByCatId(request.id);
            List<GetProductByIdResponse> res=new List<GetProductByIdResponse>();
            foreach(var product in Products)
            {
                var tmp = _mapper.Map<GetProductByIdResponse>(product);
                res.Add(tmp);
            }
           
            return Success<List<GetProductByIdResponse>>(res);




        }
        public async Task<Response<GetProductByIdResponse>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var Product = await _productService.GetProductById(request.id);

            if (Product == null) { return NotFound<GetProductByIdResponse>(); }

            var response = _mapper.Map<GetProductByIdResponse>(Product);

            return Success(response);




        }

        public async Task<Response<List<GetProductByIdResponse>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productService.GetAllProducts();
            var result = _mapper.Map<List<GetProductByIdResponse>>(products);
            return Success(result);

        }

        public async Task<PaginatedResult<GetProductByIdResponse>> Handle(GetPaginatedProductsQuery request, CancellationToken cancellationToken)
        {
            var Products = _productService.GetQueryable();
            var paginatedList = await _mapper.ProjectTo<GetProductByIdResponse>(Products).ToPaginatedListAsync(request.PageNumber, request.PageSize);
            return paginatedList;
        }

       


        #endregion
    }
}
