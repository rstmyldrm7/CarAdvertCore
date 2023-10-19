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
                id= advert.id,
                memberId = advert.memberId,
                cityId = advert.cityId,
                cityName = advert.cityName,
                townID = advert.townID,
                townName = advert.townName,
                modelId = advert.modelId,
                modelName = advert.modelName,
                year = advert.year,
                price = advert.price,
                title = advert.title,
                date = advert.date.ToString("yyyy-MM-dd HH-mm-ss"),
                categoryId = advert.categoryId,
                category = advert.category,
                km = advert.km,
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
    }
}
