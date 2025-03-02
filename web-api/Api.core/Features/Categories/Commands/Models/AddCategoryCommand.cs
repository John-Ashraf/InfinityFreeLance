using Api.Core.Bases;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Api.Core.Features.Categories.Commands.Models
{
    public class AddCategoryCommand : IRequest<Response<string>>
    {
        public string Name { get; set; }
        public string NameAr { get; set; }

        public IFormFile Photo { get; set; }
    }
}
