using Api.Data.Entities.Tables;
using Api.Infrastructure.InfrastructureBases;

namespace Api.Infrastructure.Abstracts
{
    public interface ICategoryRepository : IGenericRepoAsync<Category>
    {
    }
}
