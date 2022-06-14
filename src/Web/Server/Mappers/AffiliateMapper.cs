using QRCodeMenu.Server.Mappers.Base;
using QRCodeMenu.Server.Data.Entities;
using QRCodeMenu.Shared.Dto;

namespace QRCodeMenu.Server.Mappers;

public class AffiliateMapper : IBaseDtoMapper<Affiliate, AffiliateDto>, IBaseBackMapper<Affiliate, AffiliateDto>
{
    public AffiliateDto Map(Affiliate entity)
    {
        var address = entity.Address;
        var addressDto = new AffiliateAddressDto
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

    public Affiliate MapBack(AffiliateDto dto)
    {

        var addressDto = dto.Address;
        var address = new AffiliateAddress()
        {
            AffiliateId = dto.Id,
            City = addressDto.City,
            Country = addressDto.Country,
            Region = addressDto.Region,
            Street = addressDto.Street,
        };

        return new Affiliate()
        {
            Address = address,
            Id = dto.Id,
            IndividualMenuId = dto.IndividualMenuId,
            RestaurantId = dto.RestaurantId,
        };
    }

    public Affiliate MapUpdate(Affiliate entity, AffiliateDto dto)
    {
        entity.Address.City = dto.Address.City;
        entity.Address.Country = dto.Address.Country;
        entity.Address.Region = dto.Address.Region;
        entity.Address.Street = dto.Address.Street;

        entity.IndividualMenuId = dto.IndividualMenuId;
        entity.RestaurantId = dto.RestaurantId;
        return entity;
    }
}