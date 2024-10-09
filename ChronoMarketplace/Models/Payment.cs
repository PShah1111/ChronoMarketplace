using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using ChronoMarketplace.Areas.Identity.Data;
using ChronoMarketplace.Models;

namespace ChronoMarketplace.Models
{
    public class Payment
    {
        public enum PMethod
        {
            [Display(Name = "Credit/Debit Card")] Card,
            [Display(Name = "Digital Wallet: Apple Pay, Google Pay, Paypal")] DigitalWallet,
            [Display(Name = "Bank Transfer")] BankTransfer

        }

        [Key]
        public int PaymentId { get; set; } //Primary Key

        
        [Required]
        [DisplayName("Amount to Pay")]
        [Range(500, 90000)] // Allows the input of Minimum Product Price of 500 dollars and Maximum Product Price of 90 thousand dollars and any price in between
        [RegularExpression("^(?!0\\.00$)([1-9]\\d{0,4}(\\.\\d{1,2})?)$", ErrorMessage = "Please enter a Valid Amount")]
        public decimal PayAmount { get; set; }

        [Required]
        [DisplayName("Please select your payment method")]
        public PMethod PayMethod { get; set; }

        [Required]
        [DisplayName("Payment Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime PayDate { get; set; } 

        public Payment()
        {
            PayDate = DateTime.Now;
        }

        public ShoppingOrder ShoppingOrder { get; set; } // One to Many Relationship: One Shopping Order Associated w/ Many Payments



    }
}


