using Api.Data.Entities.Tables;
using Api.Infrastructure.Abstracts;
using Api.Infrastructure.Data;
using Api.Infrastructure.InfrastructureBases;
using Microsoft.EntityFrameworkCore;

namespace Api.Infrastructure.Repositories
{
    public class CategoryRepository : GenericRepoAsync<Category>, ICategoryRepository
    {
        #region Fields
        private readonly DbSet<Order> _userRefreshToken;
        #endregion
        #region Constructor
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
            _userRefreshToken = context.Set<Order>();

        }

        #endregion
    }
}
