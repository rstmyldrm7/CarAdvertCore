using CarAdvertCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAdvertCore.Application.Contracts.Persistence
{
    public interface IVisitRepository : IAsyncRepository<Visit>
    {
    }
}
