using Api.Data.Entities.Tables;
using Api.Infrastructure.Abstracts;
using Api.Infrastructure.Data;
using Api.Infrastructure.InfrastructureBases;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Infrastructure.Repositories;
public class CustomOrderRepository:GenericRepoAsync<CustomOrder>,ICustomOrderRepository
{
    #region Fields
    private readonly DbSet<CustomOrder> _customOrderRepository;
    #endregion
    #region Constructor
    public CustomOrderRepository(ApplicationDbContext context) : base(context)
    {
        _customOrderRepository = context.Set<CustomOrder>();

    }

    #endregion
}
