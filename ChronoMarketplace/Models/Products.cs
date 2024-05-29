using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ChronoMarketplace.Models
{
    public class Products
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
        [DisplayName("Payemnt Date")]
        [DataType(DataType.Date)]
        public string? Pay_date { get; set; }

        public Categories Categories  { get; set; }
        public Shopping_Cart ?Shopping_Cart { get; set; }
    }
}
