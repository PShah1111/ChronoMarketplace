using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ChronoMarketplace.Models
{
    public class Shopping_Cart
    {

        public int cart_ID { get; set; }

        [Required]
        [DisplayName("Customer ID")]
        public int customer_ID { get; set; }

        [Required]
        [DisplayName("Product ID")]
        public int product_ID { get; set; }

        [Required]
        [DisplayName("Payment Method")]
        public string pay_method { get; set; }

        [Required]
        [DisplayName("Quantity")]
        public int quantity { get; set; }

        [Required]
        [DisplayName("Total Price")]
        public int total_price { get; set; }

    }
}
