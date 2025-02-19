using Api.Core.Bases;
using Api.Core.Features.Orders.Queries.Models;
using Api.Core.Features.Orders.Queries.Responses;
using Api.Service.Abstracts;
using AutoMapper;
using MediatR;

namespace Api.Core.Features.Orders.Queries.Handlers
{
    public class OrderQueriesHandler : ResponseHandler, IRequestHandler<GetOrdersListQuery, Response<List<GetSingleOrderResponse>>>
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
        #region Fields
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