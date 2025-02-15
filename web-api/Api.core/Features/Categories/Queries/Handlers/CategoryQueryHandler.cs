using Api.Core.Bases;
using Api.Core.Features.Categories.Queries.Models;
using Api.Core.Features.Categories.Queries.Response;
using Api.Service.Abstracts;
using MediatR;

namespace Api.Core.Features.Categories.Queries.Handlers
{
    public class CategoryQueryHandler : ResponseHandler, IRequestHandler<GetCategoriesListQuery, Response<List<GetSingleCategoryResponse>>>
                                                        , IRequestHandler<GetCategoryByIdQuery, Response<GetSingleCategoryResponse>>
    {

        #region Fields
        private readonly ICategoryService _categoryService;
        #endregion
        #region Constructor
        public CategoryQueryHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<Response<List<GetSingleCategoryResponse>>> Handle(GetCategoriesListQuery request, CancellationToken cancellationToken)
        {
            var response = new List<GetSingleCategoryResponse>();
            var Categories = await _categoryService.GetCategoriesList();
            foreach (var Category in Categories)
            {
                response.Add(new GetSingleCategoryResponse { Name = Category.Name, id = Category.Id });
            }
            return Success(response);

        }

        public async Task<Response<GetSingleCategoryResponse>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await _categoryService.GetCategoryByIdAsync(request.Id);
            if (category == null)
            {
                return NotFound<GetSingleCategoryResponse>();
            }
            var response = new GetSingleCategoryResponse { id = category.Id, Name = category.Name };
            return Success(response);
        }

        #endregion
    }
}
