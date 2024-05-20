using System.ComponentModel;

namespace ChronoMarketplace.Models
{
    public class Shopping_Order
    {

        public int order_ID { get; set; }

        [Required]
        [DisplayName("Customer ID")]
        public int customer_ID { get; set; }

        [Required]
        [DisplayName("Cart ID")]
        public int cart_ID { get; set; }

        [Required]
        [DisplayName("Payment ID")]
        public int payment_ID { get; set; }

        [Required]
        [DisplayName("Order Date")]
        public int order_date { get; set; }

        [Required]
        [DisplayName("Shipment Date")]
        public int shipment_date { get; set; }

    }
}
