using Api.Core.Bases;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Api.Core.Features.Products.Commands.Models
{
    public class EditProductCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameAr { get; set; }

        public decimal Price { get; set; }

        public List<IFormFile> Photos { get; set; }

        public string Description { get; set; }
        public int CategoryId { get; set; }
    }
}
