namespace QRCodeMenu.Shared.Dto
{
    public record DishesGroupDto
    {
        public DishesGroupDto()
        {
            Name = string.Empty;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int RestaurantId { get; set; }
        
        public IEnumerable<DishDto> Dishes {get;set;}
        
        public RestaurantDto Restaurant { get; set; }

    }
}
