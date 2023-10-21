using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarAdvertCore.Application.Contracts.Persistence;
using CarAdvertCore.Domain.Entities;
using Microsoft.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace CarAdvertCore.Persistence.Repositories
{
    public class CarAdvertRepository : BaseRepository<Adverts>, ICarAdvertRepository
    {
        SqlConnection sqlcon = null;

        public CarAdvertRepository(IConfiguration configuration) : base(configuration)
        {
            sqlcon = new SqlConnection(configuration["DbConnectionString"]);
        }

        public async Task<Adverts> GetAdvertByIdAsync(long id)
        {
            var advert = await sqlcon.QuerySingleOrDefaultAsync<Adverts>("SELECT * FROM dbo.Adverts WHERE Id = @Id", new { id });
            return advert;
        }

        public async Task<int> GetAllAdvertsByFiltersCountQuery(string countSql, object parameters)
        {
            var x = await sqlcon.QuerySingleOrDefaultAsync<int>(countSql, parameters);
            return x;
        }

        public async Task<List<Adverts>> GetAllAdvertsByFiltersQuery(string sql, object parameters)
        {
            var advertsList = await sqlcon.QueryAsync<Adverts>(sql, parameters);
            return advertsList.ToList();
        }
    }
}
