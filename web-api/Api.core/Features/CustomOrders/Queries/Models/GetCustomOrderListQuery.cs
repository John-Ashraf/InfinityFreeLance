using Api.Core.Bases;
using Api.Core.Features.CustomOrders.Queries.Responses;
using MediatR;

namespace Api.Core.Features.CustomOrders.Queries.Models
{
    public class GetCustomOrderListQuery : IRequest<Response<List<SingleCustomOrderResponse>>>
    {
    }
}
