using QRCodeMenu.Server.Data.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QRCodeMenu.Server.Data.Entities
{
    public class Dish : IBaseEntity
    {
        public Dish()
        {
            Name = String.Empty;

            Restaurant = null!;
            Ingredients = new List<Ingredient>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; init; }

        [Required]
        public string Name { get; set; }

        [ForeignKey(nameof(Restaurant))]
        public int RestaurantId { get; set; }

        [ForeignKey(nameof(Group))]
        public int GroupId { get; set; }

        public DishesGroup Group { get; set; }
        public Restaurant Restaurant { get; set; }
        public virtual ICollection<Ingredient> Ingredients { get; set; }
        public virtual ICollection<Menu> SpecialMenus { get; set; }
    }
}
