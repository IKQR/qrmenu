namespace QRCodeMenu.Server.Dto
{
    public class RestaurantDto
    {
        public RestaurantDto()
        {
            Name = string.Empty;

            Affiliates = Array.Empty<AffiliateDto>();
            Menus = Array.Empty<MenuDto>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<AffiliateDto> Affiliates { get; set; }
        public IEnumerable<MenuDto> Menus { get; set; }
    }
}
