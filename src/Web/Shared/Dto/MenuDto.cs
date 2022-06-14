using System.Diagnostics.CodeAnalysis;

namespace QRCodeMenu.Shared.Dto
{
    public record MenuDto
    {
        public MenuDto()
        {
            Restaurant = null;
            Dishes = Array.Empty<DishDto>();
            SubName = string.Empty;
        }
        public int Id { get; init; }
        public int RestaurantId { get; set; }
        public bool IsMain { get; set; }
        public string SubName { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset UpdatedDate { get; set; }
        public RestaurantDto? Restaurant { get; set; }
        
        public IEnumerable<DishDto> Dishes { get; set; }
    }
}