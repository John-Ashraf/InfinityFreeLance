using Api.Core.Features.Orders.Commands.Models;
using Api.Core.Features.Orders.Queries.Models;
using Api.Core.Features.Products.Queries.Models;
using Api.Data.AppMetaData;
using Microsoft.AspNetCore.Mvc;
using web_api.Base;

namespace web_api.Controllers
{

    [ApiController]
    public class OrderController : AppControllerBase
    {
        [HttpPost(Router.OrderRoute.Create)]
        public async Task<IActionResult> CreateOrder([FromForm] AddOrderCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpDelete(Router.OrderRoute.Delete)]
        public async Task<IActionResult> DeleteOrder([FromRoute] DeleteOrderCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [HttpGet(Router.OrderRoute.GetAll)]
        public async Task<IActionResult> GetOrderList()
        {
            var response = await Mediator.Send(new GetOrdersListQuery());
            return NewResult(response);
        }
        [HttpGet(Router.OrderRoute.Paginated)]
        public async Task<IActionResult> GetPaginatedOrders([FromQuery] GetPaginatedOrdersQuery Query)
        {
            var response = await Mediator.Send(Query);
            return Ok(response);
        }
        [HttpGet(Router.OrderRoute.GetByID)]
        public async Task<IActionResult> GetOrderById(int id)
        {
            {
                var response = await Mediator.Send(new GetOrderByIdQuery { Id = id });
                return NewResult(response);
            }
        }
    }
}
