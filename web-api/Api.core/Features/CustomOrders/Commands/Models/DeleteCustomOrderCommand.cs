using Api.Core.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Core.Features.CustomOrders.Commands.Models;
public class DeleteCustomOrderCommand:IRequest<Response<string>>
{
    public int Id { get; set; }
}
