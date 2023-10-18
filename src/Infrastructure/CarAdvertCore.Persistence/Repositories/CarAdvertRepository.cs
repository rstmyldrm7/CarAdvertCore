using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarAdvertCore.Application.Contracts.Persistence;
using CarAdvertCore.Domain.Entities;

namespace CarAdvertCore.Persistence.Repositories
{
    public class CarAdvertRepository : BaseRepository<ToDo>, ICarAdvertRepository
    {
    }
}
