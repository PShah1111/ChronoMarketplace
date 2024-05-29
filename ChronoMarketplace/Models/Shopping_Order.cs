using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ChronoMarketplace.Models
{
    public class Shopping_Order
    {

        public int Order_ID { get; set; }

        [Required]
        [DisplayName("Customer ID")]
        public int Customer_ID { get; set; }

        [Required]
        [DisplayName("Cart ID")]
        public int Cart_ID { get; set; }

        [Required]
        [DisplayName("Payment ID")]
        public int Payment_ID { get; set; }

        [Required]
        [DisplayName("Order Date")]
        public int Order_date { get; set; }

        [Required]
        [DisplayName("Shipment Date")]
        public int Shipment_date { get; set; }

        public User ?User { get; set; }
        public Payment Payment { get; set; }
        public Shopping_Cart Shopping_Cart { get; set; }

    }
}
