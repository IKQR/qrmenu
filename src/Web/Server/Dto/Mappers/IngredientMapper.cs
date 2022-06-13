﻿using QRCodeMenu.Server.Data.Entities;
using QRCodeMenu.Server.Dto.Mappers.Base;

namespace QRCodeMenu.Server.Dto.Mappers;

public class IngredientMapper : IBaseDtoMapper<Ingredient, IngredientDto>
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
}