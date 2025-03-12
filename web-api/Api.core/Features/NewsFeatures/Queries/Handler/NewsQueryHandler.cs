using Api.Core.Bases;
using Api.Core.Features.NewsFeatures.Queries.Models;
using Api.Core.Features.NewsFeatures.Queries.Responses;
using Api.Service.Abstracts;
using MediatR;

namespace Api.Core.Features.NewsFeatures.Queries.Handler
{
    public class NewsQueryHandler : ResponseHandler, IRequestHandler<GetNewsByIdQuery, Response<SingleNewsResponse>>,
                                    IRequestHandler<GetNewsListQuery, Response<List<SingleNewsResponse>>>
    {
        #region Fields
        private readonly INewsService _newsService;
        #endregion
        #region Constructor
        public NewsQueryHandler(INewsService newsService)
        {
            _newsService = newsService;
        }


        #endregion
        #region HandleFunctions
        public async Task<Response<SingleNewsResponse>> Handle(GetNewsByIdQuery request, CancellationToken cancellationToken)
        {
            var res = await _newsService.GetNewsByIdasync(request.id);
            if (res == null) { return NotFound<SingleNewsResponse>(); }
            var response = new SingleNewsResponse { Content = res.Content, Id = res.Id, Photo = res.Image, Title = res.Title };
            return Success<SingleNewsResponse>(response);
        }

        public async Task<Response<List<SingleNewsResponse>>> Handle(GetNewsListQuery request, CancellationToken cancellationToken)
        {
            var NewsList = await _newsService.GetNewsListasync();
            var response = new List<SingleNewsResponse>();
            foreach (var item in NewsList)
            {
                var tmp = new SingleNewsResponse { Content = item.Content, Id = item.Id, Photo = item.Image, Title = item.Title };
                response.Add(tmp);
            }
            return Success<List<SingleNewsResponse>>(response);
        }
        #endregion
    }
}
