namespace QRCodeMenu.Shared.Dto
{
    public record DishDto
    {
        public DishDto()
        {
            Name = string.Empty;
            Ingredients = Array.Empty<IngredientDto>();
            SpecialMenus = Array.Empty<MenuDto>();
        }

        public int Id { get; init; }
        public string Name { get; set; }
        
        public int RestaurantId { get; set; }

        public int GroupId { get; set; }
        
        
        public IEnumerable<IngredientDto> Ingredients { get; set; }
        public IEnumerable<MenuDto> SpecialMenus { get; set; }
        
        public RestaurantDto RestaurantDto { get; set; }
        
        public DishesGroupDto DishesGroupDto { get; set; }
    }
}