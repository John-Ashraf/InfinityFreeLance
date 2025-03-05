using Api.Data.Entities.Tables;
using Microsoft.AspNetCore.Http;

namespace Api.Service.Abstracts
{
    public interface INewsService
    {
        Task<string> AddNewsasync(News news, IFormFile photo);
        Task<string> DeleteNewsasync(int id);
        Task<string> EditNewsasync(News news);
        Task<List<News>> GetNewsListasync();
        IQueryable<News> GetNewsQueryableasync();
    }
}
