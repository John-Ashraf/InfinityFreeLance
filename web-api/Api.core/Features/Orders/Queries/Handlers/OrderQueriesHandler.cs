using Api.Core.Bases;
using Api.Core.Features.Orders.Queries.Models;
using Api.Core.Features.Orders.Queries.Responses;
using Api.Data.Entities.Tables;
using Api.Service.Abstracts;
using AutoMapper;
using MediatR;
using School.Core.Wrappers;

namespace Api.Core.Features.Orders.Queries.Handlers
{
    public class OrderQueriesHandler : ResponseHandler,
            IRequestHandler<GetOrdersListQuery, Response<List<GetSingleOrderResponse>>>,
            IRequestHandler<GetPaginatedOrdersQuery, PaginatedResult<Order>>,
            IRequestHandler<GetOrderByIdQuery, Response<GetSingleOrderResponse>>
    {
        #region Fields
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
        #endregion
        #region Constructor
        public OrderQueriesHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }
        #endregion
        #region Function Handler
        public async Task<Response<List<GetSingleOrderResponse>>> Handle(GetOrdersListQuery request, CancellationToken cancellationToken)
        {
            var OrderList = await _orderService.GetOrderListAsync();
            var Result = new List<GetSingleOrderResponse>();
            foreach (var order in OrderList)
            {
                var tmp = new GetSingleOrderResponse();
                tmp.Address = order.Address;
                tmp.ProductId = order.ProductId ?? -1;
                tmp.Id = order.Id;
                tmp.Size = order.Size;
                tmp.Phone = order.Phone;
                tmp.Name = order.Name;
                tmp.Email = order.Email;
                tmp.Notes = order.Notes;
                tmp.PicsCustom = order.PicsCustom;
                tmp.Quantity = order.Quantity;
                tmp.TotalPrice = order.TotalPrice;
                tmp.Date = order.Date;
                Result.Add(tmp);
            }
            // var Result = _mapper.Map<List<GetSingleOrderResponse>>(OrderList);
            return Success(Result);
        }
        public async Task<PaginatedResult<Order>> Handle(GetPaginatedOrdersQuery request, CancellationToken cancellationToken)
        {
            _ = new List<GetSingleOrderResponse>();
            var Orders = _orderService.GetQueryable();
            var paginatedList = await Orders.ToPaginatedListAsync(request.PageNumber, request.PageSize);

            return paginatedList;
        }
        public async Task<Response<GetSingleOrderResponse>> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {

            var order = await _orderService.GetOrderById(request.Id);
            if (order == null)
            {
                return NotFound<GetSingleOrderResponse>();
            }
            var tmp = new GetSingleOrderResponse();
            tmp.Address = order.Address;
            tmp.ProductId = (order.ProductId == 0) ? -1 : (int)order.ProductId;
            tmp.Id = order.Id;
            tmp.Size = order.Size;
            tmp.Phone = order.Phone;
            tmp.Notes = order.Notes;
            tmp.PicsCustom = order.PicsCustom;
            tmp.Quantity = order.Quantity;
            tmp.TotalPrice = order.TotalPrice;
            tmp.Name = order.Name;
            tmp.Email = order.Email;
            tmp.Date = order.Date;

            return Success(tmp);
        }
        #endregion
    }
}
