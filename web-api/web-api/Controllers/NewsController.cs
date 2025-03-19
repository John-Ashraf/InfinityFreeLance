using Api.Core.Features.NewsFeatures.Commands.Models;
using Api.Core.Features.NewsFeatures.Queries.Models;
using Api.Data.AppMetaData;
using Microsoft.AspNetCore.Mvc;
using web_api.Base;

namespace web_api.Controllers
{

    [ApiController]
    public class NewsController : AppControllerBase
    {
        [HttpPost(Router.NewsRoute.Create)]
        public async Task<IActionResult> CreateNews([FromForm] AddNewsCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpDelete(Router.NewsRoute.Delete)]
        public async Task<IActionResult> CreateNews([FromRoute] int id)
        {
            var response = await Mediator.Send(new DeleteNewsCommand { id = id });
            return NewResult(response);
        }
        [HttpGet(Router.NewsRoute.GetByID)]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await Mediator.Send(new GetNewsByIdQuery { id = id });
            return NewResult(response);
        }
        [HttpGet(Router.NewsRoute.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var response = await Mediator.Send(new GetNewsListQuery());
            return NewResult(response);
        }
        [HttpGet(Router.NewsRoute.Paginated)]
        public async Task<IActionResult> GetPaginatedList([FromQuery] GetNewsPaginatedQuery Query)
        {
            var response = await Mediator.Send(new GetNewsPaginatedQuery { PageSize = Query.PageSize, PageNumber = Query.PageNumber });
            return Ok(response);
        }
    }
}
