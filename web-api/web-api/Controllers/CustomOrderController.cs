using Api.Core.Features.CustomOrders.Commands.Models;
using Api.Core.Features.CustomOrders.Queries.Models;
using Api.Data.AppMetaData;
using Microsoft.AspNetCore.Mvc;
using web_api.Base;

namespace web_api.Controllers;

[ApiController]
public class CustomOrderController : AppControllerBase
{
    [HttpPost(Router.CustomOrder.Create)]
    public async Task<IActionResult> CreateCustomOrder([FromForm] AddCustomOrderCommand command)
    {
        var response = await Mediator.Send(command);
        return NewResult(response);
    }
    [HttpDelete(Router.CustomOrder.Delete)]
    public async Task<IActionResult> DeleteCustomOrder([FromRoute] int id)
    {
        var response = await Mediator.Send(new DeleteCustomOrderCommand { Id = id });
        return NewResult(response);
    }
    [HttpGet(Router.CustomOrder.GetByID)]
    public async Task<IActionResult> GetCustomOrderById([FromRoute] int id)
    {
        var response = await Mediator.Send(new GetCustomOrderByIdQuery { id = id });
        return NewResult(response);
    }
    [HttpGet(Router.CustomOrder.GetAll)]
    public async Task<IActionResult> GetCutomOrdersList()
    {
        var response = await Mediator.Send(new GetCustomOrderListQuery());
        return NewResult(response);
    }
}
