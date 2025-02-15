using Api.Core.Bases;
using Api.Core.Features.Categories.Commands.Models;
using Api.Data.Entities.Tables;
using Api.Service.Abstracts;
using MediatR;

namespace Api.Core.Features.Categories.Commands.Handers
{
    public class CategoryCommandHandler : ResponseHandler, IRequestHandler<AddCategoryCommand, Response<string>>,
                                                        IRequestHandler<DeleteCategoryCommand, Response<string>>,
                                                        IRequestHandler<EditCategoryCommand, Response<string>>
    {
        #region Fields
        private readonly ICategoryService _categoryService;
        #endregion
        #region Constructor
        public CategoryCommandHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        #endregion
        #region HandleFunctions

        public async Task<Response<string>> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            var res = await _categoryService.AddCategoryAsync(request.Name);
            if (res == "Success")
            {
                return Created<string>("Created");
            }
            return BadRequest<string>(res);
        }

        public async Task<Response<string>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var res = await _categoryService.DeleteCategoryAsync(request.id);
            if (res == "Success")
            {
                return Success<string>("Deleted");
            }
            else if (res == "CategoryIsNotExist")
            {
                return NotFound<string>(res);

            }
            return BadRequest<string>(res);
        }

        public async Task<Response<string>> Handle(EditCategoryCommand request, CancellationToken cancellationToken)
        {
            Category category = new Category { Id = request.Id, Name = request.Name };
            var res = await _categoryService.EditCategoryAsync(category);
            if (res == "Success")
            {
                return Success<string>("Success");
            }
            return BadRequest<string>(res);
        }
        #endregion
    }
}
