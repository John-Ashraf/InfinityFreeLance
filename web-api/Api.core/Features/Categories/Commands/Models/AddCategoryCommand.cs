using Api.Core.Bases;
using MediatR;

namespace Api.Core.Features.Categories.Commands.Models
{
    public class AddCategoryCommand : IRequest<Response<string>>
    {
        public string Name { get; set; }
    }
}
