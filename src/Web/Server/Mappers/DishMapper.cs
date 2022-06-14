using QRCodeMenu.Server.Data.Entities;
using QRCodeMenu.Server.Dto;
using QRCodeMenu.Server.Dto.Mappers.Base;

namespace QRCodeMenu.Server.Mappers;

public class DishMapper : IBaseDtoMapper<Dish, DishDto>
{
    public DishDto Map(Dish entity)
    {
        return new DishDto()
        {
            Name = entity.Name,
            GroupId = entity.GroupId,
            Id = entity.Id,
            RestaurantId = entity.RestaurantId,
        };
    }
}