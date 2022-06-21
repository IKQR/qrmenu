using QRCodeMenu.Server.Mappers.Base;
using QRCodeMenu.Server.Data.Entities;
using QRCodeMenu.Shared.Dto;

namespace QRCodeMenu.Server.Mappers;

public class DishMapper : IBaseDtoMapper<Dish, DishDto>, IBaseBackMapper<Dish, DishDto>
{
    public DishDto Map(Dish entity)
    {
        return new DishDto()
        {
            Name = entity.Name,
            GroupId = entity.GroupId,
            Id = entity.Id,
            RestaurantId = entity.RestaurantId,
            Ingredients = entity.Ingredients.Select(x => new IngredientDto
            {
                Id = x.Id,
                Name = x.Name,
            }),
        };
    }

    public Dish MapBack(DishDto dto)
    {
        return new Dish()
        {
            GroupId = dto.GroupId,
            Id = dto.Id,
            Name = dto.Name,
            RestaurantId = dto.RestaurantId,
        };
    }

    public Dish MapUpdate(Dish entity, DishDto dto)
    {
        entity.GroupId = dto.GroupId;
        entity.Name = dto.Name;
        entity.RestaurantId = dto.RestaurantId;
        return entity;
    }
}