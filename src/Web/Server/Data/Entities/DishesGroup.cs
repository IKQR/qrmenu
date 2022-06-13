using QRCodeMenu.Server.Data.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QRCodeMenu.Server.Data.Entities
{
    public class DishesGroup : IBaseEntity
    {
        public DishesGroup()
        {
            Dishes = new List<Dish>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; init; }

        [Required]
        public int Name { get; set; }
        [ForeignKey(nameof(Restaurant))]
        public int RestaurantId { get; set; }

        public Restaurant Restaurant { get; set; }

        public ICollection<Dish> Dishes { get; set; }
    }

}
