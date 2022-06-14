using QRCodeMenu.Server.Mappers.Base;
using QRCodeMenu.Server.Data.Entities;
using QRCodeMenu.Shared.Dto;

namespace QRCodeMenu.Server.Mappers;

public class DishesGroupMapper : IBaseDtoMapper<DishesGroup, DishesGroupDto>, 
    IBaseBackMapper<DishesGroup, DishesGroupDto>
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

    public DishesGroup MapBack(DishesGroupDto dto)
    {
        return new DishesGroup()
        {
            Id = dto.Id,
            Name = dto.Name,
            RestaurantId = dto.RestaurantId,
        };
    }

    public DishesGroup MapUpdate(DishesGroup entity, DishesGroupDto dto)
    {
        entity.Name = dto.Name;
        entity.RestaurantId = dto.RestaurantId;
        return entity;
    }
}