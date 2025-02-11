using Api.Core.Bases;
using Api.Core.Features.Products.Queries.Response;
using MediatR;

namespace Api.Core.Features.Products.Queries.Models
{
    public class GetAllProductsQuery : IRequest<Response<List<GetProductByIdResponse>>>
    {
    }
}
