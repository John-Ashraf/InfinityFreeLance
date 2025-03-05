using Api.Data.Entities.Tables;
using Api.Infrastructure.Abstracts;
using Api.Infrastructure.Data;
using Api.Infrastructure.InfrastructureBases;
using Microsoft.EntityFrameworkCore;

namespace Api.Infrastructure.Repositories
{
    public class NewsRespository : GenericRepoAsync<News>, INewsRepository
    {
        #region Fields
        private readonly DbSet<News> _newsRepository;
        #endregion
        #region Constructor
        public NewsRespository(ApplicationDbContext context) : base(context)
        {
            _newsRepository = context.Set<News>();

        }

        #endregion
    }
}
