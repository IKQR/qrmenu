namespace QRCodeMenu.Server.Dto
{
    public record AffiliateDto
    {
        public int Id { get; init; }
        public int RestaurantId { get; set; }
        public int? IndividualMenuId { get; set; }
        
        public AffiliateAddressDto Address { get; set; }

        public record AffiliateAddressDto
        {
            public AffiliateAddressDto()
            {
                Country = string.Empty;
                Region = string.Empty;
                City = string.Empty;
                Street = string.Empty;
            }

            public string Country { get; set; } 
            public string Region { get; set; }
            public string City { get; set; }
            public string Street { get; set; }
        }
    }
}