using Api.Core.Bases;
using MediatR;

namespace Api.Core.Features.Products.Commands.Models
{
    public class AddproductCommand : IRequest<Response<string>>
    {
        public string Name { get; set; } = String.Empty;

        public decimal Price { get; set; }

        public List<string> Photos { get; set; } = new List<string>();

        public string Description { get; set; } = String.Empty;
    }
}
