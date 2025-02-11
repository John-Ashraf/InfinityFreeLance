using Api.Core.Features.Products.Queries.Response;
using MediatR;
using School.Core.Wrappers;

namespace Api.Core.Features.Products.Queries.Models
{
    public class GetPaginatedProductsQuery : IRequest<PaginatedResult<GetProductByIdResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
