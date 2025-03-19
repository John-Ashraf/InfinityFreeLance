using Api.Data.Entities.Tables;
using MediatR;
using School.Core.Wrappers;

namespace Api.Core.Features.NewsFeatures.Queries.Models
{
    public class GetNewsPaginatedQuery : IRequest<PaginatedResult<News>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
