using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using ChronoMarketplace.Areas.Identity.Data;

namespace ChronoMarketplace.Models
{
    public class Payment
    {

        [Key]
        public int PaymentId { get; set; } //Primary Key

        [Required]
        [DisplayName("User ID")]
        public ChronoMarketplaceUser UserId { get; set; }

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


    }
}
