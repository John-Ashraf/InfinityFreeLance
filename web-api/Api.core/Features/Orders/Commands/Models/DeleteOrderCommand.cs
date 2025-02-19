using Api.Core.Bases;
using MediatR;

namespace Api.Core.Features.Orders.Commands.Models
{
    public class DeleteOrderCommand : IRequest<Response<string>>
    {
        public int id { get; set; }
        public DeleteOrderCommand(int id)
        {
            this.id = id;
        }
    }
}
