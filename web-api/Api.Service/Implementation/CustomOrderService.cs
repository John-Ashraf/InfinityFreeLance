using Api.Data.Entities.Tables;
using Api.Infrastructure.Abstracts;
using Api.Infrastructure.Data;
using Api.Service.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Api.Service.Implementation;
public class CustomOrderService : ICustomOrderService
{
    #region Fields
    private readonly ICustomOrderRepository _customOrderRepository;
    private readonly IFileService _fileService;
    private readonly ApplicationDbContext _dbcontext;
    private readonly IHttpContextAccessor _httpContextAccessor;

    #endregion
    #region Constructor
    public CustomOrderService(ICustomOrderRepository customOrderRepository,
        IFileService fileService, ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
    {
        _customOrderRepository = customOrderRepository;
        _fileService = fileService;
        _dbcontext = context;
        _httpContextAccessor = httpContextAccessor;
    }
    #endregion
    #region HandleFunctions
    public async Task<string> CreateCustomOrder(CustomOrder customOrder, List<IFormFile> photos)
    {
        var trans = _dbcontext.Database.BeginTransaction();
        var context = _httpContextAccessor.HttpContext.Request;
        var baseUrl = context.Scheme + "://" + context.Host;
        try
        {
            foreach (var photo in photos)
            {
                var photourl = await _fileService.UploadImage("CustomOrder", photo);
                customOrder.Photos.Add(baseUrl.ToString() + photourl.ToString());
            }
            _ = await _customOrderRepository.AddAsync(customOrder);
            trans.Commit();
        }
        catch
        (Exception ex)
        {
            trans.Rollback();

            return ex.ToString() + "  " + ex.Message.ToString();
        }
        return "Success";
    }
    public async Task<string> DeleteCustomOrder(int id)
    {
        var customOrder = _customOrderRepository.GetTableNoTracking().Where(x => x.Id == id).SingleOrDefault();
        if (customOrder is null)
        {
            return "Not Found";
        }

        await _customOrderRepository.DeleteAsync(customOrder);

        return "Success";
    }

    public async Task<CustomOrder> GetCustomOrderById(int id)
    {
        return await _customOrderRepository.GetByIdAsync(id);
    }

    public async Task<List<CustomOrder>> GetCustomOrders()
    {
        return await _customOrderRepository.GetTableNoTracking().ToListAsync();
    }
    #endregion

}
