using Api.Data.Entities.Tables;
using Api.Infrastructure.InfrastructureBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Infrastructure.Abstracts;
public interface ICustomOrderRepository:IGenericRepoAsync<CustomOrder>
{
}
