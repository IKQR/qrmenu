using QRCodeMenu.Server.Mappers.Base;
using QRCodeMenu.Server.Data.Entities;
using QRCodeMenu.Shared.Dto;

namespace QRCodeMenu.Server.Mappers;

public class IngredientMapper : IBaseDtoMapper<Ingredient, IngredientDto>, IBaseBackMapper<Ingredient, IngredientDto>
{
    public IngredientDto Map(Ingredient entity)
    {
        return new IngredientDto()
        {
            Id = entity.Id,
            Name = entity.Name,
            RestaurantId = entity.Id
        };
        
    }

    public Ingredient MapBack(IngredientDto dto)
    {
        return new Ingredient()
        {
            Id = dto.Id,
            Name = dto.Name,
            RestaurantId = dto.RestaurantId,
        };
    }

    public Ingredient MapUpdate(Ingredient entity, IngredientDto dto)
    {
        entity.Name = dto.Name;
        entity.RestaurantId = dto.RestaurantId;
        return entity;
    }
}