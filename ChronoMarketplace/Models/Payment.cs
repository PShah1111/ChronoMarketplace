using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using ChronoMarketplace.Areas.Identity.Data;
using ChronoMarketplace.Models;

namespace ChronoMarketplace.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; } //Primary Key

        
        [Required]
        [DisplayName("Amount to Pay")]
        [RegularExpression("^(?!0\\.00$)([1-9]\\d{0,4}(\\.\\d{1,2})?)$", ErrorMessage = "Please enter a Valid Amount")]
        public decimal Payamount { get; set; }

        [Required]
        [DisplayName("Payment Method")]
        public string Paymethod { get; set; }

        [Required]
        [DisplayName("Payment Date")]
        [DataType(DataType.Date)]
        public DateTime Paydate { get; set; }
        public int ShoppingOrderId { get; set; } 

        public ShoppingOrder ShoppingOrder { get; set; } // One to Many Relationship: One Shopping Order Associated w/ Many Payments

        public Payment()
        {
            Paydate = DateTime.Now;
        }



    }
}


