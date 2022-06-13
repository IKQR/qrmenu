namespace QRCodeMenu.Server.Dto
{
    public record MenuDto
    {
        public int Id { get; init; }
        public int RestaurantId { get; set; }

        public RestaurantDto Restaurant { get; set; }
        public virtual ICollection<DishDto> Dishes { get; set; }
    }
}