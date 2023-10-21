using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarAdvertCore.Application.Contracts.Persistence;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using Dapper;
using static Dapper.SqlMapper;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Data.Common;
using System.Net.Mail;
using CarAdvertCore.Domain.Entities;
using Microsoft.Extensions.Configuration;

namespace CarAdvertCore.Persistence.Repositories
{
    public class BaseRepository<T> :
        IAsyncRepository<T> where T : class
    {
        SqlConnection sqlcon = null;

        public BaseRepository(IConfiguration configuration)
        {
            sqlcon = new SqlConnection(configuration["DbConnectionString"]);
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            await sqlcon.InsertAsync<Guid,T>(entity);
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

       
    }
}
