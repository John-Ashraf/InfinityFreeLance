using Api.Core.Bases;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Api.Core.Features.NewsFeatures.Commands.Models
{
    public class AddNewsCommand : IRequest<Response<string>>
    {
        public string Title { get; set; }
        public string TitleAr { get; set; }
        public string Content { get; set; }
        public string ContentAr { get; set; }
        public IFormFile Photo { get; set; }

    }
}
