using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ChronoMarketplace.Models
{
   public class Shopping_Cart
    {

        [Key] public int Cart_ID { get; set; }

        [Required]
        [DisplayName("User ID")]
        public int User_ID { get; set; }

        [Required]
        [DisplayName("Product ID")]
        public int Product_ID { get; set; }

        [Required]
        [DisplayName("Quantity")]
        public int Quantity { get; set; }

        [Required]
        [DisplayName("Total Price")]
        public int Total_price { get; set; }

        public ICollection<Shopping_Order> Shopping_Orders { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
