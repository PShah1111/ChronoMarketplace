using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ChronoMarketplace.Models
{
    public class Payment
    {

        [Key] public int PaymentId { get; set; }

        [Required]
        [DisplayName("Customer ID")]
        public int CustomerId { get; set; }

        [Required]
        [DisplayName("Amount to Pay")]
        public int Payamount { get; set; }

        [Required]
        [DisplayName("Payment Method")]
        public string? Paymethod { get; set; }

        [Required]
        [DisplayName("Payment Date")]
        [DataType(DataType.Date)]
        public DateTime Paydate { get; set; }

        public ICollection<ShoppingOrder> ShoppingOrders { get; set; }
        public ICollection<User> Users { get; set; }

    }
}
