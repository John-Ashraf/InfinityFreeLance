using Api.Core.Bases;
using Api.Core.Features.News.Commands.Models;
using Api.Service.Abstracts;
using MediatR;

namespace Api.Core.Features.News.Commands.Handler
{
    public class NewsCommandHandler : ResponseHandler, IRequestHandler<AddNewsCommand, Response<string>>
    {
        #region Fields
        private readonly INewsService _newService;
        #endregion
        #region Constructor
        public NewsCommandHandler(INewsService newsService)
        {
            _newService = newsService;
        }


        #endregion
        #region HandleFunctions
        public Task<Response<string>> Handle(AddNewsCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
