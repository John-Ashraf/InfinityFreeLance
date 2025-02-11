using Api.Data.Entities.Tables;
using Api.Infrastructure.Abstracts;
using Api.Infrastructure.Data;
using Api.Infrastructure.InfrastructureBases;
using Microsoft.EntityFrameworkCore;

namespace Api.Infrastructure.Repositories
{
    internal class ProductRepository : GenericRepoAsync<Product>, IProductRepository
    {
        #region Fields
        private readonly DbSet<Product> _products;
        #endregion
        #region Constructor
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
            _products = context.Set<Product>();

        }
        #endregion

    }
}
