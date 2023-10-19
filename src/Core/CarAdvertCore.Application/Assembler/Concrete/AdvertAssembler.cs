using CarAdvertCore.Application.Assembler.Abstract;
using CarAdvertCore.Application.Features.Tasks.Queries.QueryModels.Response;
using CarAdvertCore.Domain.Entities;
using CarAdvertCore.Domain.Enums;
using CarAdvertCore.Domain.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAdvertCore.Application.Assembler.Concrete
{
    public class AdvertAssembler : IAdvertAssembler
    {
        public GetAdvertByIdQueryResponse MapToGetAdvertByIdResponse(Adverts advert)
        {
            return new GetAdvertByIdQueryResponse()
            {
                id = advert.id.ToString(),
                memberId = advert.memberId.ToString(),
                cityId = advert.cityId.ToString(),
                cityName = advert.cityName.ToString(),
                townID = advert.townID.ToString(),
                townName = advert.townName.ToString(),
                modelId = advert.modelId.ToString(),
                modelName = advert.modelName,
                year = advert.year.ToString(),
                price = advert.price.ToString(),
                title = advert.title,
                date = advert.date.ToString("yyyy-MM-dd HH-mm-ss"),
                categoryId = advert.categoryId.ToString(),
                category = advert.category.ToString(),
                km = advert.km.ToString(),
                color = advert.color,
                gear = EnumHelper<GearType>.GetDisplayValue(advert.gearType),
                fuel = EnumHelper<FuelType>.GetDisplayValue(advert.fuelType),
                firstPhoto = advert.firstPhoto,
                secondPhoto = advert.secondPhoto,
                userInfo = advert.userInfo,
                userPhone = advert.userPhone,
                text = advert.text
            };
        }

        public GetAllAdvertsQueryResponse MapToGetAllAdvertsQueryResponse(List<Adverts> adverts, int pageSize, int totalCount)
        {
            List<AdvertsDto> advertsDtoList = adverts.Select(advert => new AdvertsDto
            {
                id = advert.id.ToString(),
                modelName = advert.modelName,
                category = advert.category,
                year = advert.year.ToString(),
                price = advert.price.ToString(),
                title = advert.title,
                date = advert.date.ToString("yyyy-MM-dd HH-mm-ss"),
                km = advert.km.ToString(),
                color = advert.color,
                gear = EnumHelper<GearType>.GetDisplayValue(advert.gearType),
                fuel = EnumHelper<FuelType>.GetDisplayValue(advert.fuelType),
                firstPhoto = advert.firstPhoto
            }).ToList();

            return new GetAllAdvertsQueryResponse()
            {
                page = pageSize,
                total = totalCount,
                adverts = advertsDtoList
            };
        }
    }
}
