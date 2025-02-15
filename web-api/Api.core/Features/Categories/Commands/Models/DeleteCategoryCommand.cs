using Api.Core.Bases;
using MediatR;

namespace Api.Core.Features.Categories.Commands.Models
{
    public class DeleteCategoryCommand : IRequest<Response<string>>
    {
        public int id { get; set; }
    }
}
