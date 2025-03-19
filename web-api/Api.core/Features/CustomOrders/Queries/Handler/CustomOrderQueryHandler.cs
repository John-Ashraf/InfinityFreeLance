using Api.Core.Bases;
using Api.Core.Features.CustomOrders.Queries.Models;
using Api.Core.Features.CustomOrders.Queries.Responses;
using Api.Service.Abstracts;
using MediatR;

namespace Api.Core.Features.CustomOrders.Queries.Handler
{
    public class CustomOrderQueryHandler : ResponseHandler,
            IRequestHandler<GetCustomOrderByIdQuery, Response<SingleCustomOrderResponse>>,
            IRequestHandler<GetCustomOrderListQuery, Response<List<SingleCustomOrderResponse>>>
    {
        #region Fields
        private readonly ICustomOrderService _customOrderService;
        #endregion
        #region Constructor
        public CustomOrderQueryHandler(ICustomOrderService customOrderService)
        {
            _customOrderService = customOrderService;
        }

        #endregion
        #region HandleFunction
        public async Task<Response<SingleCustomOrderResponse>> Handle(GetCustomOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var tmp = await _customOrderService.GetCustomOrderById(request.id);
            if (tmp == null) { return NotFound<SingleCustomOrderResponse>(); }
            var res = new SingleCustomOrderResponse
            {
                Id = tmp.Id,
                Name = tmp.Name,
                Email = tmp.Email,
                Photos = tmp.Photos,
                Address = tmp.Address,
                Notes = tmp.Notes,
                Size = tmp.Size,
            };
            return Success<SingleCustomOrderResponse>(res);
        }

        public async Task<Response<List<SingleCustomOrderResponse>>> Handle(GetCustomOrderListQuery request, CancellationToken cancellationToken)
        {
            var tmp = await _customOrderService.GetCustomOrders();
            var res = new List<SingleCustomOrderResponse>();
            foreach (var item in tmp)
            {
                var tmpt = new SingleCustomOrderResponse
                {
                    Id = item.Id,
                    Name = item.Name,
                    Email = item.Email,
                    Photos = item.Photos,
                    Address = item.Address,
                    Notes = item.Notes,
                    Size = item.Size,

                };
                res.Add(tmpt);
            }
            return Success<List<SingleCustomOrderResponse>>(res);
        }
        #endregion
    }
}
