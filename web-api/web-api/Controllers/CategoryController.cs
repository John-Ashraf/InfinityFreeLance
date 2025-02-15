using Api.Core.Features.Categories.Commands.Models;
using Api.Core.Features.Categories.Queries.Models;
using Api.Data.AppMetaData;
using Microsoft.AspNetCore.Mvc;
using web_api.Base;

namespace web_api.Controllers
{

    [ApiController]
    public class CategoryController : AppControllerBase

    {
        [HttpGet(Router.CategoryRoute.GetAll)]
        public async Task<IActionResult> GetAllCategories()
        {
            var response = await Mediator.Send(new GetCategoriesListQuery());
            return Ok(response);
        }
        [HttpGet(Router.CategoryRoute.GetByID)]
        public async Task<IActionResult> GetAllCategories([FromRoute] int id)
        {
            var response = await Mediator.Send(new GetCategoryByIdQuery { Id = id });
            return Ok(response);
        }
        [HttpPost(Router.CategoryRoute.Create)]
        public async Task<IActionResult> CreateCategory([FromForm] AddCategoryCommand Command)
        {
            var response = await Mediator.Send(Command);
            return Ok(response);
        }

        [HttpDelete(Router.CategoryRoute.Delete)]
        public async Task<IActionResult> DeleteCategory([FromRoute] int id)
        {
            var response = await Mediator.Send(new DeleteCategoryCommand { id = id });
            return Ok(response);
        }
    }
}
