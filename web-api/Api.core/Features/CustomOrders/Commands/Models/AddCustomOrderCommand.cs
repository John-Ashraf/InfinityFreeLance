using Api.Core.Bases;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Api.Core.Features.CustomOrders.Commands.Models;
public class AddCustomOrderCommand : IRequest<Response<string>>
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Size { get; set; }
    public string Notes { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public double TotalPrice { get; set; }
    public List<IFormFile> Photos { get; set; }
}
