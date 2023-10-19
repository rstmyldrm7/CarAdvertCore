using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarAdvertCore.Application.Contracts.Persistence;
using CarAdvertCore.Domain.Entities;
using Microsoft.Data.SqlClient;
using Dapper;

namespace CarAdvertCore.Persistence.Repositories
{
    public class CarAdvertRepository : BaseRepository<Adverts>, ICarAdvertRepository
    {
        SqlConnection sqlcon = null;

        public CarAdvertRepository()
        {
            sqlcon = new SqlConnection("Server=(LocalDb)\\MSSQLLocalDb;Initial Catalog=CarAdvertCore;Integrated Security=True;\r\n");
        }

        public async Task<Adverts> GetAdvertByIdAsync(long id)
        {
            var advert = await sqlcon.QuerySingleOrDefaultAsync<Adverts>("SELECT * FROM dbo.Adverts WHERE Id = @Id", new { id });
            return advert;
        }
    }
}
