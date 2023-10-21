using AutoMapper;
using CarAdvertCore.Application.Assembler.Abstract;
using CarAdvertCore.Application.Assembler.Concrete;
using CarAdvertCore.Application.Contracts.Persistence;
using CarAdvertCore.Application.Features.Tasks.Queries.QueryModels.Request;
using CarAdvertCore.Application.Features.Tasks.Queries.QueryModels.Response;
using CarAdvertCore.Application.Features.Tasks.Service.Abstract;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CarAdvertCore.Application.Features.Tasks.Queries.Handler
{
    public class GetAdvertByIdQueryHandler :
        IRequestHandler<GetAdvertByIdQueryRequest, GetAdvertByIdQueryResponse>
    {
        private readonly ICarAdvertRepository _carAdvertRepository;
        private readonly IAdvertAssembler _advertAssembler;
        private readonly IApacheService _apacheService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public GetAdvertByIdQueryHandler(ICarAdvertRepository carAdvertRepository, IAdvertAssembler advertAssembler, IApacheService apacheService, IHttpContextAccessor httpContextAccessor)
        {
            _carAdvertRepository = carAdvertRepository;
            _advertAssembler = advertAssembler;
            _apacheService = apacheService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<GetAdvertByIdQueryResponse> Handle(GetAdvertByIdQueryRequest request,
            CancellationToken cancellationToken)
        {
            var httpContext = _httpContextAccessor.HttpContext;
            string clientIpAddress = httpContext.Connection.RemoteIpAddress.ToString();
            var advert = await _carAdvertRepository.GetAdvertByIdAsync(request.Id);

            if (advert == null)
            {
                return null;
            }

            #region KafkaSend
            await _apacheService.MapToVisitEvent(advert, clientIpAddress);
            #endregion

            return _advertAssembler.MapToGetAdvertByIdResponse(advert);
        }
    }
}
