using QRCodeMenu.Server.Mappers.Base;
using QRCodeMenu.Server.Data.Entities;
using QRCodeMenu.Shared.Dto;

namespace QRCodeMenu.Server.Mappers
{
    public class RestaurantMapper : IBaseDtoMapper<Restaurant, RestaurantDto>, IBaseBackMapper<Restaurant, RestaurantDto>
    {
        public RestaurantDto Map(Restaurant entity)
        {
            return new RestaurantDto()
            {
                Id = entity.Id,
                Name = entity.Name,
            };
        }
        public Restaurant MapBack(RestaurantDto dto)
        {
            return new Restaurant()
            {
                Id = dto.Id,
                Name = dto.Name,
            };
        }

        public Restaurant MapUpdate(Restaurant entity, RestaurantDto dto)
        {
            entity.Name = dto.Name;
            return entity;
        }
    }
}
