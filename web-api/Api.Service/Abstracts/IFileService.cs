using Microsoft.AspNetCore.Http;

namespace Api.Service.Abstracts
{
    public interface IFileService
    {
        public Task<string> UploadImage(string Location, IFormFile file);
        Task<string> DeleteImage(string Location, string fileName);
    }
}
