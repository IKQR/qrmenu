﻿using QRCodeMenu.Server.Data.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QRCodeMenu.Server.Data.Entities
{
    public class Menu : IBaseEntity
    {
        public Menu()
        {
            Dishes = new List<Dish>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; init; }

        [ForeignKey(nameof(Restaurant))]
        public int RestaurantId { get; set; }

        public Restaurant Restaurant { get; set; }
        public virtual ICollection<Dish> Dishes { get; set; }
    }
}
