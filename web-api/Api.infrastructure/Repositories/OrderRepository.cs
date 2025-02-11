using Api.Data.Entities.Tables;
using Api.Infrastructure.Abstracts;
using Api.Infrastructure.Data;
using Api.Infrastructure.InfrastructureBases;
using Microsoft.EntityFrameworkCore;

namespace Api.Infrastructure.Repositories
{
    public class OrderRepository : GenericRepoAsync<Order>, IOrderRepository
    {
        #region Fields
        private readonly DbSet<Order> _userRefreshToken;
        #endregion
        #region Constructor
        public OrderRepository(ApplicationDbContext context) : base(context)
        {
            _userRefreshToken = context.Set<Order>();

        }

        #endregion
    }
}
