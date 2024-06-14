using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using ChronoMarketplace.Areas.Identity.Data;

namespace ChronoMarketplace.Models
{
   public class ShoppingCart
    {
        [Required]
        [Key] public int CartId { get; set; }

        [Required]
        [DisplayName("User ID")]
        public ChronoMarketplaceUser UserId { get; set; }

        [Required]
        [DisplayName("Product ID")]
        public int ProductId { get; set; }

        [Required]
        [DisplayName("Quantity")]
        public int Quantity { get; set; }

        [Required]
        [DisplayName("Total Price")]
        public int Totalprice { get; set; }

        public ICollection<ShoppingOrder> ShoppingOrders { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
