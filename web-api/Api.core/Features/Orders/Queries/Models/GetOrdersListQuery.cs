using Api.Core.Bases;
using Api.Core.Features.Orders.Queries.Responses;
using MediatR;

namespace Api.Core.Features.Orders.Queries.Models
{
    public class GetOrdersListQuery : IRequest<Response<List<GetSingleOrderResponse>>>
    {
    }
}
