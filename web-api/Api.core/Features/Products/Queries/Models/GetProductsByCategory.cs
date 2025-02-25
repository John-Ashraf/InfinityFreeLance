using Api.Core.Bases;
using Api.Core.Features.Products.Queries.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Core.Features.Products.Queries.Models
{
    class GetProductsByCategory:IRequest<Response<List<GetProductByIdResponse>>>
    {
        public int id { get; set; }
    }
}
