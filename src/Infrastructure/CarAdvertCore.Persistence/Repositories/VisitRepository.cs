using CarAdvertCore.Application.Contracts.Persistence;
using CarAdvertCore.Domain.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAdvertCore.Persistence.Repositories
{
    public class VisitRepository : BaseRepository<Visit>, IVisitRepository
    {
        public VisitRepository(IConfiguration configuration) : base(configuration)
        {

        }
    }
}
