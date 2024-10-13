using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using ChronoMarketplace.Areas.Identity.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChronoMarketplace.Models
{
    public class Payment
    {
        public enum PMethod
        {
            [Display(Name = "Credit/Debit Card")] 
            Card,
            [Display(Name = "Digital Wallet: Apple Pay, Google Pay, Paypal")] 
            DigitalWallet,
            [Display(Name = "Bank Transfer")] 
            BankTransfer

        }

        [Key]
        [Required]
        [DisplayName("Payment ID")] 
        public int PaymentId { get; set; } // Primary Key

        [Required]
        [DisplayName("Shopping Order Name")]
        public int ShoppingOrderId { get; set; } // Shopping Order ID Property


        [Required]
        [DisplayName("Amount to Pay")] // Displays the custom 'Amount to Pay' instead of property name
        [Range(1, 500000)] // Allows the input of Minimum Payment Amount of 1 dollar and Maximum Payment Amount of 500 thousand dollars and any price in between
        [RegularExpression("^(?!0\\.00$)([1-9]\\d{0,5}(\\.\\d{1,2})?)$", ErrorMessage = "Please enter a Valid Amount")]
        // RegEx doesn't allow $0.00, allows non-zero starting digit (1-9) with a max of 5 digits following and 1 or 2 d.p.
        [DataType(DataType.Currency)] // Represents currency value and displays currency symbol
        public decimal PayAmount { get; set; } // Payment Amount Property

        [Required]
        [DisplayName("Please Select your Payment Method")] // Displays the custom 'Please Select your Payment Method' instead of property name
        public PMethod PayMethod { get; set; } // Refers to the 'PMethod' enum

        [Required]
        [DisplayName("Payment Date")] // Displays the custom 'Payment Date' instead of property name
        [DataType(DataType.Date)] // Date Validation: Client Side Validation 
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)] 
        // Date Format - day/month/year, Format is same when date is being edited in a form
        public DateTime PayDate { get; set; } // Payment Date Property

        public Payment()
        {
            PayDate = DateTime.Now; // Initialises new payment by setting 'PayDate' to current date and time the payment was created
        }

        public ShoppingOrder ShoppingOrder { get; set; } // One to Many Relationship: One Shopping Order Associated w/ Many Payments


    }
}


