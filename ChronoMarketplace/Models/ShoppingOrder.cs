using ChronoMarketplace.Areas.Identity.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ChronoMarketplace.Models
{
    public class ShoppingOrder
    {

        [Key] public int OrderId { get; set; }

        [Required]
        [DisplayName("User ID")]
        public ChronoMarketplaceUser UserId { get; set; }

        [Required]
        [DisplayName("Cart ID")]
        public int CartId { get; set; }

        [Required]
        [DisplayName("Payment ID")]
        public int PaymentId { get; set; }

        [Required]
        [DisplayName("Order Date")]
        [DataType(DataType.Date)]
        public DateTime Orderdate { get; set; }

        [Required]
        [DisplayName("Shipment Date")]
        [DataType(DataType.Date)]
        public DateTime Shipmentdate { get; set; }

        public ICollection<Payment> Payments { get; set; }
        public ICollection<ShoppingCart> ShoppingCarts { get; set; }

    }
}

