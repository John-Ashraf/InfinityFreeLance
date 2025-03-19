using Api.Data.Entities.Tables;
using Api.Infrastructure.Abstracts;
using Api.Service.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Api.Service.Implementation
{
    public class NewsService : INewsService
    {
        #region Fields
        private readonly IFileService _fileService;
        private readonly INewsRepository _newRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        #endregion
        #region Constructor
        public NewsService(INewsRepository newsRepository, IFileService fileService, IHttpContextAccessor httpContextAccessor)
        {
            _newRepository = newsRepository;
            _fileService = fileService;
            _httpContextAccessor = httpContextAccessor;
        }

        #endregion
        #region HandleFunction
        public async Task<string> AddNewsasync(News news, IFormFile photo)
        {
            var context = _httpContextAccessor.HttpContext.Request;
            var baseUrl = context.Scheme + "://" + context.Host;
            var imageUrl = await _fileService.UploadImage("News", photo);
            news.Image = baseUrl + imageUrl;

            _ = await _newRepository.AddAsync(news);
            return "Success";
        }

        public async Task<string> DeleteNewsasync(int id)
        {
            var tmp = await _newRepository.GetByIdAsync(id);
            if (tmp == null) return "NotFound";
            await _newRepository.DeleteAsync(tmp);
            return "Success";
        }

        public async Task<string> EditNewsasync(News news)
        {
            await _newRepository.UpdateAsync(news);
            return "Success";
        }

        public async Task<News> GetNewsByIdasync(int id)
        {
            return await _newRepository.GetByIdAsync(id);
        }

        public async Task<List<News>> GetNewsListasync()
        {
            return await _newRepository.GetTableNoTracking().ToListAsync();
        }

        public IQueryable<News> GetNewsQueryableasync()
        {
            return _newRepository.GetTableNoTracking().AsQueryable();
        }
        #endregion
    }
}
