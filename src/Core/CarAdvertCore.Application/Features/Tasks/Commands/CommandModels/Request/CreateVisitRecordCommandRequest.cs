using CarAdvertCore.Application.Features.Tasks.Commands.CommandModels.Response;
using MediatR;
using NSwag.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAdvertCore.Application.Features.Tasks.Commands.CommandModels.Request
{
    public class CreateVisitRecordCommandRequest : IRequest<CreateVisitRecordCommandResponse>
    {
        public long advertId { get; set; }
    }
}
