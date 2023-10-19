using CarAdvertCore.Application.Assembler.Abstract;
using CarAdvertCore.Application.Contracts.Persistence;
using CarAdvertCore.Application.Features.Tasks.Queries.QueryModels.Request;
using CarAdvertCore.Application.Features.Tasks.Queries.QueryModels.Response;
using CarAdvertCore.Domain.Entities;
using CarAdvertCore.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CarAdvertCore.Application.Features.Tasks.Queries.Handler
{
    public class GetAllAdvertsQueryHandler :
        IRequestHandler<GetAllAdvertsQueryRequest, GetAllAdvertsQueryResponse>
    {
        private readonly ICarAdvertRepository _carAdvertRepository;
        private readonly IAdvertAssembler _advertAssembler;
        public GetAllAdvertsQueryHandler(ICarAdvertRepository carAdvertRepository, IAdvertAssembler advertAssembler)
        {
            _carAdvertRepository = carAdvertRepository;
            _advertAssembler = advertAssembler;
        }

        public async Task<GetAllAdvertsQueryResponse> Handle(GetAllAdvertsQueryRequest request,
            CancellationToken cancellationToken)
        {
            var sql = "SELECT * FROM Adverts WHERE 1=1";
            var countSql = "SELECT COUNT(*) FROM Adverts WHERE 1=1";

            if (request.filteringFields != null)
            {
                if (request.filteringFields.categoryId != null && request.filteringFields.categoryId.Any())
                {
                    sql += " AND CategoryId IN @CategoryIds";
                    countSql += " AND CategoryId IN @CategoryIds";
                }

                if (request.filteringFields.PriceFrom.HasValue)
                {
                    sql += " AND Price >= @PriceFrom";
                    countSql += " AND Price >= @PriceFrom";
                }

                if (request.filteringFields.PriceTo.HasValue)
                {
                    sql += " AND Price <= @PriceTo";
                    countSql += " AND Price <= @PriceTo";
                }

                if (request.filteringFields.gears != null && request.filteringFields.gears.Any())
                {
                    sql += " AND GearType IN @GearTypes";
                    countSql += " AND GearType IN @GearTypes";
                }

                if (request.filteringFields.fuel != null && request.filteringFields.fuel.Any())
                {
                    sql += " AND FuelType IN @FuelTypes";
                    countSql += " AND FuelType IN @FuelTypes";
                }
            }

            
            sql += GetSortClause(request.Field, request.Direction);
            sql += " OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";

            var parameters = new
            {
                CategoryIds = request.filteringFields?.categoryId,
                PriceFrom = request.filteringFields?.PriceFrom,
                PriceTo = request.filteringFields?.PriceTo,
                GearTypes = request.filteringFields?.gears,
                FuelTypes = request.filteringFields?.fuel,
                Offset = (request.PageNumber - 1) * request.PageSize,
                PageSize = request.PageSize
            };

            var totalCount = await _carAdvertRepository.GetAllAdvertsByFiltersCountQuery(countSql, parameters);
            
            if (totalCount == 0)
            {
                return null;
            }
            var advertsList = await _carAdvertRepository.GetAllAdvertsByFiltersQuery(sql, parameters);

            
            return _advertAssembler.MapToGetAllAdvertsQueryResponse(advertsList, request.PageSize, totalCount);
        }
        private string GetSortClause(SortField? field, SortDirection? direction)
        {
            switch (field)
            {
                case SortField.Price:
                    return direction == SortDirection.HighToLow ? " ORDER BY Price DESC" : " ORDER BY Price ASC";
                case SortField.Year:
                    return direction == SortDirection.HighToLow ? " ORDER BY Year DESC" : " ORDER BY Year ASC";
                case SortField.Km:
                    return direction == SortDirection.HighToLow ? " ORDER BY Km DESC" : " ORDER BY Km ASC";
                default:
                    return "ORDER BY Year DESC";
            }
        }
    }
}
