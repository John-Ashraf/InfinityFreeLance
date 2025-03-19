using Api.Core.Bases;
using Api.Core.Features.NewsFeatures.Commands.Models;
using Api.Data.Entities.Tables;
using Api.Service.Abstracts;
using MediatR;

namespace Api.Core.Features.NewsFeatures.Commands.Handler
{
    public class NewsCommandHandler : ResponseHandler, IRequestHandler<AddNewsCommand, Response<string>>
                , IRequestHandler<DeleteNewsCommand, Response<string>>
    {
        #region Fields
        private readonly INewsService _newsService;
        #endregion
        #region Constructor
        public NewsCommandHandler(INewsService newsService)
        {
            _newsService = newsService;
        }

        #endregion
        #region HandleFunctions

        public async Task<Response<string>> Handle(AddNewsCommand request, CancellationToken cancellationToken)
        {
            News newstmp = new News
            {
                Content = request.Content,
                Title = request.Title,
                ContentAr = request.ContentAr,
                TitleAr = request.TitleAr,
                LastUpdate = DateTime.UtcNow
            };
            var res = await _newsService.AddNewsasync(newstmp, request.Photo);
            if (res == "Success")
            {
                return Created<string>("Success");
            }
            return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(DeleteNewsCommand request, CancellationToken cancellationToken)
        {
            var res = await _newsService.DeleteNewsasync(request.id);
            if (res == "NotFound") return NotFound<string>(res);
            return Deleted<string>(res);
        }
        #endregion
    }
}
