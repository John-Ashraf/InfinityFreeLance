using Api.Core.Bases;
using Api.Core.Features.NewsFeatures.Queries.Responses;
using MediatR;

namespace Api.Core.Features.NewsFeatures.Queries.Models
{
    public class GetNewsByIdQuery : IRequest<Response<SingleNewsResponse>>
    {
        public int id { get; set; }
    }
}
