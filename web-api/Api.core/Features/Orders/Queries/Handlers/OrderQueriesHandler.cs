using Api.Core.Bases;
using Api.Core.Features.Orders.Queries.Models;
using Api.Core.Features.Orders.Queries.Responses;
using Api.Core.Features.Products.Queries.Models;
using Api.Core.Features.Products.Queries.Response;
using Api.Data.Entities.Tables;
using Api.Service.Abstracts;
using Api.Service.Implementation;
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
            var Result = new List<GetSingleOrderResponse>();
            var Orders = _orderService.GetQueryable();
            var paginatedList = await Orders.ToPaginatedListAsync(request.PageNumber, request.PageSize);
           
            return paginatedList;
        }
        public async Task<Response<GetSingleOrderResponse>> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
           
            var order=await _orderService.GetOrderById(request.Id);
            if (order == null)
            {
                return NotFound<GetSingleOrderResponse>();
            }
            var tmp = new GetSingleOrderResponse();
            tmp.Address = order.Address;
            tmp.ProductId = order.ProductId ?? -1;
            tmp.Id = order.Id;
            tmp.Size = order.Size;
            tmp.Phone = order.Phone;
            tmp.Notes = order.Notes;
            tmp.PicsCustom = order.PicsCustom;
            tmp.Quantity = order.Quantity;
            tmp.TotalPrice = order.TotalPrice;
            tmp.Date = order.Date;

            return Success(tmp);
        }
        #endregion
    }
}
/*
    public int Id { get; set; }
      public decimal TotalPrice { get; set; }
      public int ProductId { get; set; }
      public int Quantity { get; set; }

      public DateTime Date { get; set; }

      public string Size { get; set; } // Assuming sizes are stored as a comma-separated string

      public string Phone { get; set; }

      public string Address { get; set; }

      public string Notes { get; set; }

      public List<string> PicsCustom { get; set; } = new List<string>();
   */