using QRCodeMenu.Server.Data.Entities;
using QRCodeMenu.Server.Dto;
using QRCodeMenu.Server.Dto.Mappers.Base;

namespace QRCodeMenu.Server.Mappers
{
    public class RestaurantMapper : IBaseDtoMapper<Restaurant, RestaurantDto>
    {
        public RestaurantDto Map(Restaurant entity)
        {
            return new RestaurantDto()
            {
                Id = entity.Id,
                Name = entity.Name,
            };
        }
    }
}
