using QRCodeMenu.Server.Data.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QRCodeMenu.Server.Data.Entities
{
    public class Affiliate : IBaseEntity
    {
        public Affiliate()
        {
            Restaurant = null!;
            Address = null!;
        }

        public int Id { get; init; }

        [ForeignKey(nameof(Restaurant))]
        public int RestaurantId { get; set; }

        [ForeignKey(nameof(IndividualMenu))]
        public int? IndividualMenuId { get; set; }
        
        public virtual Restaurant Restaurant { get; set; }
        public virtual AffiliateAddress Address { get; set; }

        public virtual Menu? IndividualMenu { get; set; }
    }

    public class AffiliateAddress
    {
        public AffiliateAddress()
        {
            Country = String.Empty;
            Region = String.Empty;
            City = String.Empty;
            Street = String.Empty;
            Affiliate = null!;
        }

        [Key]
        [ForeignKey(nameof(Affiliate))]
        public int AffiliateId { get; set; }

        [Required]
        public string Country { get; set; }
        [Required]
        public string Region { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Street { get; set; }

        public virtual Affiliate Affiliate { get; set; }
    }
}
