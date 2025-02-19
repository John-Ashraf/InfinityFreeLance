using Api.Data.Entities.Tables;
using Microsoft.AspNetCore.Http;

namespace Api.Service.Abstracts
{
    public interface IOrderService
    {
        Task<string> AddOrderAsync(Order order, List<IFormFile> photos);
        Task<string> DeleteOrderAsync(int id);
        Task<List<Order>> GetOrderListAsync();
    }
}
