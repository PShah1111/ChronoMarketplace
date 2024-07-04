using ChronoMarketplace.Areas.Identity.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChronoMarketplace.Models
{
    public class ShoppingOrder
    {

        [Key] 
        public int ShoppingOrderId { get; set; } //Primary Key

        [Required]
        [DisplayName("User ID")]
        public ChronoMarketplaceUser UserId { get; set; }

        [Required]
        [DisplayName("Cart ID")]
        public int CartId { get; set; }

       
        [Required]
        [DisplayName("Order Date")]
        [DataType(DataType.Date)]
        public DateTime Orderdate { get; set; }

        [Required]
        [DisplayName("Shipment Date")]
        [DataType(DataType.Date)]
        public DateTime Shipmentdate { get; set; }

        [ForeignKey("Payment")] 
        public int PaymentID { get; set; }

        public Payment Payment { get; set; } // Reference navigation to dependent 
        public ICollection<ShoppingCart> ShoppingCarts { get; set; }

    }
}

