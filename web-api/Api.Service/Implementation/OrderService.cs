using Api.Data.Entities.Tables;
using Api.Infrastructure.Abstracts;
using Api.Infrastructure.Data;
using Api.Service.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Api.Service.Implementation
{
    public class OrderService : IOrderService
    {
        #region Fields
        private readonly IOrderRepository _orderRepository;
        private readonly ApplicationDbContext _context;
        private readonly IFileService _fileService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        #endregion
        #region Constructor
        public OrderService(IOrderRepository orderRepository, ApplicationDbContext context, IFileService fileService, IHttpContextAccessor httpContextAccessor)
        {
            _orderRepository = orderRepository;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _fileService = fileService;
        }

        #endregion
        #region HandleFuctions

        public async Task<string> AddOrderAsync(Order order, List<IFormFile> photos)
        {
            var context = _httpContextAccessor.HttpContext.Request;
            var baseUrl = context.Scheme + "://" + context.Host;
            var trans = _context.Database.BeginTransaction();

            try
            {
                foreach (var photo in photos)
                {
                    var imageUrl = await _fileService.UploadImage("Orders", photo);
                    switch (imageUrl)
                    {
                        case "NoImage": return "NoImage";
                        case "FailedToUploadImage": return "FailedToUploadImage";
                    }
                    order.PicsCustom.Add(baseUrl + imageUrl);
                }

                var tmp = await _orderRepository.AddAsync(order);
                trans.Commit();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                return ex.Message;
            }
            return "Success";
        }

        public async Task<string> DeleteOrderAsync(int id)
        {
            var order = await _orderRepository.GetTableNoTracking().Where(x => x.Id == id).SingleOrDefaultAsync();
            if (order == null)
            {
                return "OrderIsNotExist";
            }
            await _orderRepository.DeleteAsync(order);
            return "Success";

        }

        public async Task<List<Order>> GetOrderListAsync()
        {
            return await _orderRepository.GetTableNoTracking().ToListAsync();
        }
        public IQueryable<Order> GetQueryable()
        {
            return _orderRepository.GetTableAsTracking().AsQueryable();
        }
        public async Task<Order> GetOrderById(int orderId)
        {
            return await _orderRepository.GetTableNoTracking().Where(x => x.Id == orderId).SingleOrDefaultAsync();
        }
        #endregion
    }
}
