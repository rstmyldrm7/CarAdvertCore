using CarAdvertCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAdvertCore.Application.Features.Tasks.Service.Abstract
{
    public interface IApacheService
    {
        Task MapToVisitEvent(Adverts advert, string ipAdress);
    }
}
