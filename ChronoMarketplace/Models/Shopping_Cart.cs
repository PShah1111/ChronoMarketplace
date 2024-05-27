using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ChronoMarketplace.Models
{
    public class Shopping_Cart
    {

        public int Cart_ID { get; set; }

        [Required]
        [DisplayName("Customer ID")]
        public int Customer_ID { get; set; }

        [Required]
        [DisplayName("Product ID")]
        public int Product_ID { get; set; }

        [Required]
        [DisplayName("Payment Method")]
        public string? Pay_method { get; set; }

        [Required]
        [DisplayName("Quantity")]
        public int Quantity { get; set; }

        [Required]
        [DisplayName("Total Price")]
        public int Total_price { get; set; }

        public ICollection<Shopping_Order>? Shopping_Order { get; set; }
        public ICollection<User>? User { get; set; }
        public ICollection<Products>? Products { get; set; }
    }
}
