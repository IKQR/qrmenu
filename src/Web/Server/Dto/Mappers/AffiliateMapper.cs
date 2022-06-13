using QRCodeMenu.Server.Data.Entities;
using QRCodeMenu.Server.Dto.Mappers.Base;

namespace QRCodeMenu.Server.Dto.Mappers;

public class AffiliateMapper : IBaseDtoMapper<Affiliate, AffiliateDto>
{
    public AffiliateDto Map(Affiliate entity)
    {
        var address = entity.Address;
        var addressDto = new AffiliateDto.AffiliateAddressDto
        {
            City = address.City,
            Country = address.Country,
            Region = address.Region,
            Street = address.Street,
        };

        return new AffiliateDto
        {
            Address = addressDto,
            Id = entity.Id,
            IndividualMenuId = entity.IndividualMenuId,
            RestaurantId = entity.RestaurantId,
        };

    }
}