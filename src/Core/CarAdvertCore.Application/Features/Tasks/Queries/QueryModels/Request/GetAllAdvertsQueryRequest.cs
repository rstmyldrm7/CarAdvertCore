using CarAdvertCore.Application.Features.Tasks.Queries.QueryModels.Response;
using CarAdvertCore.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAdvertCore.Application.Features.Tasks.Queries.QueryModels.Request
{
    public class GetAllAdvertsQueryRequest : IRequest<GetAllAdvertsQueryResponse>
    {
        public FilteringFields filteringFields {  get; set; }
        public SortField? Field { get; set; }
        public SortDirection? Direction { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
    public class FilteringFields
    {
        public List<long> categoryId { get; set; }
        public decimal? PriceFrom { get; set; }
        public decimal? PriceTo { get; set; }
        public List<GearType> gears { get; set; }
        public List<FuelType> fuel { get; set; }
    }
}
