using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarAdvertCore.Domain.Entities;

namespace CarAdvertCore.Application.Contracts.Persistence
{
    public interface ICarAdvertRepository : IAsyncRepository<Adverts>
    {
        Task<Adverts> GetAdvertByIdAsync(long id);
        Task<List<Adverts>> GetAllAdvertsByFiltersQuery(string sql, object parameters);
        Task<int> GetAllAdvertsByFiltersCountQuery(string countSql, object parameters);
    }
}
