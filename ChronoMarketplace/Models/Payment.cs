using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ChronoMarketplace.Models
{
    public class Payment
    {

        public int Payment_ID { get; set; }

        [Required]
        [DisplayName("Customer ID")]
        public int Customer_ID { get; set; }

        [Required]
        [DisplayName("Amount to Pay")]
        public int Pay_amount { get; set; }

        [Required]
        [DisplayName("Payment Method")]
        public string? Pay_method { get; set; }

        [Required]
        [DisplayName("Payment Date")]
        [DataType(DataType.Date)]
        public DateTime Pay_date { get; set; }

        public Shopping_Order? Shopping_Order { get; set; }
        public User User { get; set; }

    }
}
