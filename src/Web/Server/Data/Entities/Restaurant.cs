using QRCodeMenu.Server.Data.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QRCodeMenu.Server.Data.Entities
{
    public class Restaurant : IBaseEntity
    {
        public Restaurant()
        {
            Name = String.Empty;
            Affiliates = new List<Affiliate>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; init; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Affiliate> Affiliates { get; set; }
        public virtual ICollection<Menu> Menus { get; set; }
    }
}
