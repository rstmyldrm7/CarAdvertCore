using CarAdvertCore.Application.Features.Tasks.Queries.QueryModels.Response;
using CarAdvertCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAdvertCore.Application.Assembler.Abstract
{
    public interface IAdvertAssembler
    {
        GetAdvertByIdQueryResponse MapToGetAdvertByIdResponse(Adverts advert);
        GetAllAdvertsQueryResponse MapToGetAllAdvertsQueryResponse(List<Adverts> advers,int pageSize, int totalCount);
    }
}
