using QRCodeMenu.Server.Data.Entities;
using QRCodeMenu.Shared.Dto;

namespace QRCodeMenu.Server.Mappers.Base;

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
    
    public static void BackMapServices(this IServiceCollection services)
    {
        services.AddTransient<IBaseBackMapper<Affiliate, AffiliateDto>, AffiliateMapper>();
        services.AddTransient<IBaseBackMapper<DishesGroup, DishesGroupDto>, DishesGroupMapper>();
        services.AddTransient<IBaseBackMapper<Dish, DishDto>, DishMapper>();
        services.AddTransient<IBaseBackMapper<Ingredient, IngredientDto>, IngredientMapper>();
        services.AddTransient<IBaseBackMapper<Menu, MenuDto>, MenuMapper>();
        services.AddTransient<IBaseBackMapper<Restaurant, RestaurantDto>, RestaurantMapper>();
    }
}