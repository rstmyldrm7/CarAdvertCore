using CarAdvertCore.Application.Features.Tasks.Queries.QueryModels.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAdvertCore.Application.Features.Tasks.Queries.QueryModels.Request
{
    public class GetAdvertByIdQueryRequest : IRequest<GetAdvertByIdQueryResponse>
    {
        public long Id { get; set; }
    }
}
