using QRCodeMenu.Server.Data.Entities;

namespace QRCodeMenu.Server.Dto.Mappers.Base;

public static class MapperExtension
{
    public static void MapServices(this IServiceCollection services)
    {
        services.AddTransient<IBaseDtoMapper<Affiliate, AffiliateDto>, AffiliateMapper>();
        services.AddTransient<IBaseDtoMapper<DishesGroup, DishesGroupDto>, DishesGroupMapper>();
        services.AddTransient<IBaseDtoMapper<Dish, DishDto>, DishMapper>();
        services.AddTransient<IBaseDtoMapper<Ingredient, IngredientDto>, IngredientMapper>();
        services.AddTransient<IBaseDtoMapper<Menu, MenuDto>, MenuMapper>();
        services.AddTransient<IBaseDtoMapper<Restaurant, RestaurantDto>, RestaurantMapper>();
    }
}