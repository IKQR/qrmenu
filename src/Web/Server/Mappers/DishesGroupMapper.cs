using QRCodeMenu.Server.Data.Entities;
using QRCodeMenu.Server.Dto;
using QRCodeMenu.Server.Dto.Mappers.Base;

namespace QRCodeMenu.Server.Mappers;

public class DishesGroupMapper : IBaseDtoMapper<DishesGroup, DishesGroupDto>
{
    public DishesGroupDto Map(DishesGroup entity)
    {
        return new DishesGroupDto()
        {
            Id = entity.Id,
            Name = entity.Name,
            RestaurantId = entity.RestaurantId,
        };
    }
}