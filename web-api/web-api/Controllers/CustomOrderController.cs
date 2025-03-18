using Api.Core.Features.CustomOrders.Commands.Models;
using Api.Core.Features.NewsFeatures.Commands.Models;
using Api.Data.AppMetaData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using web_api.Base;

namespace web_api.Controllers;

[ApiController]
public class CustomOrderController : AppControllerBase
{
    [HttpPost(Router.CustomOrder.Create)]
    public async Task<IActionResult> CreateNews([FromForm] AddCustomOrderCommand command)
    {
        var response = await Mediator.Send(command);
        return NewResult(response);
    }
}
