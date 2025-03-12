using Api.Core.Bases;
using MediatR;

namespace Api.Core.Features.NewsFeatures.Commands.Models
{
    public class DeleteNewsCommand : IRequest<Response<string>>
    {
        public int id { get; set; }
    }
}
