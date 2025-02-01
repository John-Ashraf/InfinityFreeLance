using Api.Core.Features.Users.Commands.Models;
using Api.Core.Features.Users.Queries.Models;
using Api.Data.AppMetaData;
using Microsoft.AspNetCore.Mvc;
using web_api.Base;

namespace web_api.Controllers
{
    [ApiController]
    public class ApplicationUserController : AppControllerBase
    {
        [HttpPost(Router.ApplicationUserRouting.Create)]
        public async Task<IActionResult> CreateUser([FromBody] AddUserCommand model)
        {
            var response = await Mediator.Send(model);
            return NewResult(response);
        }
        [HttpGet(Router.ApplicationUserRouting.Paginated)]
        public async Task<IActionResult> Paginated([FromQuery] GetPaginatedListQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }
        [HttpGet(Router.ApplicationUserRouting.GetByID)]
        public async Task<IActionResult> GetUserByID([FromRoute] string id)
        {
            return NewResult(await Mediator.Send(new GetUserByIdQuery { Id = id }));
        }
        [HttpPut(Router.ApplicationUserRouting.Edit)]
        public async Task<IActionResult> EditUser([FromBody] EditUserCommand model)
        {
            var response = await Mediator.Send(model);
            return NewResult(response);
        }
        [HttpDelete(Router.ApplicationUserRouting.Delete)]
        public async Task<IActionResult> Delete([FromRoute] DeleteUserCommand model)
        {
            var response = await Mediator.Send(model);
            return NewResult(response);
        }
        [HttpPut(Router.ApplicationUserRouting.ChangePassword)]
        public async Task<IActionResult> ChangePassword([FromBody] ChangeUserPasswordCommand model)
        {
            var response = await Mediator.Send(model);
            return NewResult(response);
        }
    }
}
