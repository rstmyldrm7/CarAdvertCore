using AutoMapper;
using CarAdvertCore.Application.Assembler.Abstract;
using CarAdvertCore.Application.Assembler.Concrete;
using CarAdvertCore.Application.Contracts.Persistence;
using CarAdvertCore.Application.Features.Tasks.Queries.QueryModels.Request;
using CarAdvertCore.Application.Features.Tasks.Queries.QueryModels.Response;
using MediatR;
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
        public GetAdvertByIdQueryHandler(ICarAdvertRepository carAdvertRepository, IAdvertAssembler advertAssembler)
        {
            _carAdvertRepository = carAdvertRepository;
            _advertAssembler = advertAssembler;
        }

        public async Task<GetAdvertByIdQueryResponse> Handle(GetAdvertByIdQueryRequest request,
            CancellationToken cancellationToken)
        {
            var advert = await _carAdvertRepository.GetAdvertByIdAsync(request.Id);

            if (advert == null)
            {
                return null;
            }

            return _advertAssembler.MapToGetAdvertByIdResponse(advert);
        }
    }
}
