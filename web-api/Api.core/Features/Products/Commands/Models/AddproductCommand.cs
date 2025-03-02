using Api.Core.Bases;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Api.Core.Features.Products.Commands.Models
{
    public class AddproductCommand : IRequest<Response<string>>
    {
        public string Name { get; set; } = String.Empty;
        public string NameAr { get; set; } = String.Empty;

        public decimal Price { get; set; }

        public List<IFormFile> Photos { get; set; } = new List<IFormFile>();

        public string Description { get; set; } = String.Empty;
        public int Catid { get; set; }
    }
}
