using Api.Core.Bases;
using Api.Core.Features.NewsFeatures.Queries.Responses;
using MediatR;

namespace Api.Core.Features.NewsFeatures.Queries.Models
{
    public class GetNewsListQuery : IRequest<Response<List<SingleNewsResponse>>>
    {
    }
}
