using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarAdvertCore.Application.Contracts.Persistence;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using Dapper;
using static Dapper.SqlMapper;

namespace CarAdvertCore.Persistence.Repositories
{
    public class BaseRepository<T> :
        IAsyncRepository<T> where T : class
    {
        
        SqlConnection sqlcon = null;

        public BaseRepository()
        {
            sqlcon = new SqlConnection("ConnectionString");
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            await sqlcon.InsertAsync<T>(entity);
            return entity;
        }

        public virtual async Task UpdateAsync(T entity)
        {
            var affectedRowCount = await sqlcon.UpdateAsync<T>(entity);
        }

        public virtual async Task DeleteAsync(T entity)
        {
            await sqlcon.DeleteAsync<T>(entity);
        }

        public Task<T> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<T>> ListAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
