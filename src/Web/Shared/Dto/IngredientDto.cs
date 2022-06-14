namespace QRCodeMenu.Server.Dto
{
    public record IngredientDto
    {
        public IngredientDto()
        {
            Name = string.Empty;
        }
        public int Id { get; init; }
        
        public string Name { get; set; }
        public int RestaurantId { get; set; }

        public RestaurantDto Restaurant { get; set; }
        public virtual ICollection<DishDto> Dishes { get; set; }
    }
}
