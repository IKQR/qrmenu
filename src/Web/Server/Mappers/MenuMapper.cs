using QRCodeMenu.Server.Data.Entities;
using QRCodeMenu.Server.Dto;
using QRCodeMenu.Server.Dto.Mappers.Base;

namespace QRCodeMenu.Server.Mappers;

public class MenuMapper: IBaseDtoMapper<Menu, MenuDto>
{
    public MenuDto Map(Menu entity)
    {
        return new MenuDto()
        {
            Id = entity.Id,
            RestaurantId = entity.RestaurantId,
        };
    }
}