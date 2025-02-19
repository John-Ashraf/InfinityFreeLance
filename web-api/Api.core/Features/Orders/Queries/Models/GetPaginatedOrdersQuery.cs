using Api.Core.Features.Orders.Queries.Responses;
using Api.Core.Features.Products.Queries.Response;
using Api.Data.Entities.Tables;
using MediatR;
using School.Core.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Core.Features.Orders.Queries.Models
{
    public class GetPaginatedOrdersQuery: IRequest<PaginatedResult<Order>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
