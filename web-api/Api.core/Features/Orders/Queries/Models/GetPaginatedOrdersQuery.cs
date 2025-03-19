using Api.Data.Entities.Tables;
using MediatR;
using School.Core.Wrappers;

namespace Api.Core.Features.Orders.Queries.Models
{
    public class GetPaginatedOrdersQuery : IRequest<PaginatedResult<Order>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
