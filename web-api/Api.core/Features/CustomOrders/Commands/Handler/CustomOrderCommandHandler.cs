using Api.Core.Bases;
using Api.Core.Features.CustomOrders.Commands.Models;
using Api.Data.Entities.Tables;
using Api.Service.Abstracts;
using MediatR;

namespace Api.Core.Features.CustomOrders.Commands.Handler;
public class CustomOrderCommandHandler : ResponseHandler
        , IRequestHandler<AddCustomOrderCommand, Response<string>>
        , IRequestHandler<DeleteCustomOrderCommand, Response<string>>
{
    #region Fields
    private readonly ICustomOrderService _customOrderService;
    #endregion
    #region constructor
    public CustomOrderCommandHandler(ICustomOrderService customOrderService)
    {
        _customOrderService = customOrderService;
    }


    #endregion
    #region HandleFunctions
    public async Task<Response<string>> Handle(AddCustomOrderCommand request, CancellationToken cancellationToken)
    {
        var tmporder = new CustomOrder
        {
            Name = request.Name,
            Notes = request.Notes,
            Address = request.Address,
            Email = request.Email,
            Size = request.Size,
            TotalPrice = request.TotalPrice,
            Phone = request.Phone,
            Date = DateTime.UtcNow,

        };
        var res = await _customOrderService.CreateCustomOrder(tmporder, request.Photos);
        if (res == "Success")
        {
            return Created<string>(res);
        }
        else
        {
            return BadRequest<string>();
        }

    }

    public async Task<Response<string>> Handle(DeleteCustomOrderCommand request, CancellationToken cancellationToken)
    {
        var res = await _customOrderService.DeleteCustomOrder(request.Id);
        if (res == "Success")
        {
            return Success<string>(res);
        }
        else
        {
            return BadRequest<string>();
        }
    }
    #endregion
}
