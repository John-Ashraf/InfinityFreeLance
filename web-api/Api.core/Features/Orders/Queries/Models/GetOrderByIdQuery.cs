using Api.Core.Bases;
using Api.Core.Features.Orders.Queries.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Core.Features.Orders.Queries.Models
{
    public class GetOrderByIdQuery: IRequest<Response<GetSingleOrderResponse>>
    {
        public int Id { get; set; }
    }
}
