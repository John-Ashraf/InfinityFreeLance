using Api.Core.Bases;
using Api.Core.Features.Categories.Queries.Response;
using MediatR;

namespace Api.Core.Features.Categories.Queries.Models
{
    public class GetCategoryByIdQuery : IRequest<Response<GetSingleCategoryResponse>>
    {
        public int Id { get; set; }
    }
}
