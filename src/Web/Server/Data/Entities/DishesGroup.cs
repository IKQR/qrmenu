using QRCodeMenu.Server.Data.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QRCodeMenu.Server.Data.Entities
{
    public class DishesGroup : IBaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; init; }

        public int MyProperty { get; set; }
    }
}
