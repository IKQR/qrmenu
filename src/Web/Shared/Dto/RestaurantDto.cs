namespace QRCodeMenu.Shared.Dto
{
    public record RestaurantDto
    {
        public RestaurantDto()
        {
            Name = string.Empty;
            Description = string.Empty;

            Affiliates = Array.Empty<AffiliateDto>();
            Menus = Array.Empty<MenuDto>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public IEnumerable<AffiliateDto> Affiliates { get; set; }
        public IEnumerable<MenuDto> Menus { get; set; }
    }
}
