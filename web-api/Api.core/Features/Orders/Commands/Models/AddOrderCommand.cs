using Api.Core.Bases;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Api.Core.Features.Orders.Commands.Models
{
    public class AddOrderCommand : IRequest<Response<string>>
    {
        public int? ProductId { get; set; }
        public int Quantity { get; set; }
        public string size { get; set; }
        public string Phone { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public string? Notes { get; set; }
        public List<IFormFile>? PicsCustom { get; set; } = new List<IFormFile>();
    }
}
