using Api.Data.Entities.Tables;
using Microsoft.AspNetCore.Http;

namespace Api.Service.Abstracts;
public interface ICustomOrderService
{
    Task<string> CreateCustomOrder(CustomOrder customOrder, List<IFormFile> photos);
    Task<string> DeleteCustomOrder(int id);
}
