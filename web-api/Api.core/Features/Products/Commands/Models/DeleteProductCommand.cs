using Api.Core.Bases;
using MediatR;

namespace Api.Core.Features.Products.Commands.Models
{
    public class DeleteProductCommand : IRequest<Response<string>>
    {
        public int id { get; set; }
        public DeleteProductCommand(int id)
        {
            this.id = id;
        }
    }
}
