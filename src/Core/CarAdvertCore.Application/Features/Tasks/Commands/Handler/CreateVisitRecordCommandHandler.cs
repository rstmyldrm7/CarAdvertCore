using CarAdvertCore.Application.Assembler.Abstract;
using CarAdvertCore.Application.Contracts.Persistence;
using CarAdvertCore.Application.Features.Tasks.Commands.CommandModels.Request;
using CarAdvertCore.Application.Features.Tasks.Commands.CommandModels.Response;
using CarAdvertCore.Application.Features.Tasks.Queries.QueryModels.Request;
using CarAdvertCore.Application.Features.Tasks.Queries.QueryModels.Response;
using CarAdvertCore.Application.Features.Tasks.Service.Abstract;
using CarAdvertCore.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CarAdvertCore.Application.Features.Tasks.Commands.Handler
{
    public class CreateVisitRecordCommandHandler :
        IRequestHandler<CreateVisitRecordCommandRequest, CreateVisitRecordCommandResponse>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IVisitRepository _visitRepository;
        public CreateVisitRecordCommandHandler(IHttpContextAccessor httpContextAccessor, IVisitRepository visitRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _visitRepository = visitRepository;
        }

        public async Task<CreateVisitRecordCommandResponse> Handle(CreateVisitRecordCommandRequest request,
            CancellationToken cancellationToken)
        {
            var httpContext = _httpContextAccessor.HttpContext;
            string clientIpAddress = httpContext.Connection.RemoteIpAddress.ToString();
            var newVisit = new Visit()
            {
                ID = Guid.NewGuid(),
                advertId = request.advertId,
                iPAdress = clientIpAddress,
                visitDate = DateTime.Now
            };
            var response = await _visitRepository.AddAsync(newVisit);
            return new CreateVisitRecordCommandResponse();
        }
    }
}