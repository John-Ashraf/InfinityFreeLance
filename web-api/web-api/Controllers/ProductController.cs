using Api.Core.Features.Products.Commands.Models;
using Api.Core.Features.Products.Queries.Models;
using Api.Data.AppMetaData;
using Microsoft.AspNetCore.Mvc;
using web_api.Base;

namespace web_api.Controllers
{

    [ApiController]
    public class ProductController : AppControllerBase
    {
        [HttpGet(Router.ProductRoute.GetAll)]
        public async Task<IActionResult> GetAllProducts()
        {
            var response = await Mediator.Send(new GetAllProductsQuery());
            return NewResult(response);
        }
        [HttpGet(Router.ProductRoute.Paginated)]
        public async Task<IActionResult> GetPaginatedProducts([FromQuery] GetPaginatedProductsQuery Query)
        {
            var response = await Mediator.Send(Query);
            return Ok(response);
        }
        [HttpGet(Router.ProductRoute.GetByID)]
        public async Task<IActionResult> GetProductById([FromRoute] GetProductByIdQuery model)
        {
            var response = await Mediator.Send(model);
            return NewResult(response);
        }
        [HttpPost(Router.ProductRoute.Create)]
        public async Task<IActionResult> AddProduct([FromForm] AddproductCommand model)
        {
            var response = await Mediator.Send(model);
            return NewResult(response);
        }
        [HttpPut(Router.ProductRoute.Edit)]
        public async Task<IActionResult> EditProduct([FromForm] EditProductCommand model)
        {
            var response = await Mediator.Send(model);
            return NewResult(response);
        }
        [HttpDelete(Router.ProductRoute.Delete)]
        public async Task<IActionResult> DeleteProdutById([FromRoute] int id)
        {
            var response = await Mediator.Send(new DeleteProductCommand(id));
            return NewResult(response);
        }
    }
}
