using Api.Core.Bases;
using Api.Core.Features.Orders.Commands.Models;
using Api.Data.Entities.Tables;
using Api.Service.Abstracts;
using AutoMapper;
using MediatR;

namespace Api.Core.Features.Orders.Commands.Handlers
{
    public class OrderCommandHandler : ResponseHandler,
                                IRequestHandler<AddOrderCommand, Response<string>>,
                                IRequestHandler<DeleteOrderCommand, Response<string>>
    {
        #region Fields
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        #endregion
        #region Constructor
        public OrderCommandHandler(IOrderService orderService, IProductService productService, IMapper mapper)
        {
            _orderService = orderService;
            _productService = productService;
            _mapper = mapper;
        }


        #endregion
        #region HandleFunctions
        public async Task<Response<string>> Handle(AddOrderCommand request, CancellationToken cancellationToken)
        {

            if (request.ProductId != null)
            {
                int pid = (int)request.ProductId;
                var Product = await _productService.GetProductById(pid);
                if (Product == null)
                {
                    return BadRequest<string>("ProductIsNotExist");
                }
                var Order = _mapper.Map<Order>(request);
                Order.TotalPrice = Order.Quantity * Product.Price;

                Order.Date = DateTime.UtcNow;
                var res = await _orderService.AddOrderAsync(Order, request.PicsCustom);
                if (res == "Success")
                {
                    return Created<string>("Done");
                }
                return BadRequest<string>(res);
            }
            else
            {
                var Order = _mapper.Map<Order>(request);
                Order.TotalPrice = 9999999999;

                Order.Date = DateTime.UtcNow;
                var res = await _orderService.AddOrderAsync(Order, request.PicsCustom);
                if (res == "Success")
                {
                    return Created<string>("Done");
                }
                return BadRequest<string>(res);
            }



        }

        public async Task<Response<string>> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var res = await _orderService.DeleteOrderAsync(request.id);
            if (res == "Success")
            {
                return Success<string>("Done");
            }
            return BadRequest<string>(res);
        }
        #endregion
    }
}
