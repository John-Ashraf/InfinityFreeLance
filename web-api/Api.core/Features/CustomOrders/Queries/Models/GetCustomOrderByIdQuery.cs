using Api.Core.Bases;
using Api.Core.Features.CustomOrders.Queries.Responses;
using MediatR;

namespace Api.Core.Features.CustomOrders.Queries.Models
{
    public class GetCustomOrderByIdQuery : IRequest<Response<SingleCustomOrderResponse>>
    {

        public int id { get; set; }
    }

}
