using Api.Core.Bases;
using MediatR;

namespace Api.Core.Features.Categories.Commands.Models
{
    public class EditCategoryCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
