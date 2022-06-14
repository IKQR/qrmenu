using QRCodeMenu.Server.Mappers.Base;
using QRCodeMenu.Server.Data.Entities;
using QRCodeMenu.Shared.Dto;

namespace QRCodeMenu.Server.Mappers;

public class MenuMapper: IBaseDtoMapper<Menu, MenuDto>, IBaseBackMapper<Menu, MenuDto>
{
    public MenuDto Map(Menu entity)
    {
        return new MenuDto()
        {
            Id = entity.Id,
            RestaurantId = entity.RestaurantId,
            CreatedDate = entity.CreatedDate,
            UpdatedDate = entity.UpdatedDate,
            SubName = entity.SubName,
        };
    }
    public Menu MapBack(MenuDto dto)
    {
        return new Menu()
        {
            Id = dto.Id,
            RestaurantId = dto.RestaurantId,
            CreatedDate = DateTimeOffset.UtcNow,
            UpdatedDate = DateTimeOffset.UtcNow,
            SubName = dto.SubName
        };
    }

    public Menu MapUpdate(Menu entity, MenuDto dto)
    {
        entity.UpdatedDate = DateTimeOffset.UtcNow;
        entity.SubName = dto.SubName;
        entity.IsMain = dto.IsMain;
        return entity;
    }
}