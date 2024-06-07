using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ChronoMarketplace.Models
{
    public class Shopping_Order
    {

        [Key] public int Order_ID { get; set; }

        [Required]
        [DisplayName("User ID")]
        public int User_ID { get; set; }

        [Required]
        [DisplayName("Cart ID")]
        public int Cart_ID { get; set; }

        [Required]
        [DisplayName("Payment ID")]
        public int Payment_ID { get; set; }

        [Required]
        [DisplayName("Order Date")]
        [DataType(DataType.Date)]
        public DateTime Order_date { get; set; }

        [Required]
        [DisplayName("Shipment Date")]
        [DataType(DataType.Date)]
        public DateTime Shipment_date { get; set; }

        public User User { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public ICollection<Shopping_Cart> Shopping_Carts { get; set; }

    }
}

