using ChronoMarketplace.Areas.Identity.Data;
using ChronoMarketplace.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChronoMarketplace.Models
{

    public class ShoppingOrder
    {

        [Key]
        [Required]
        [DisplayName("Shopping Order ID")] 
        public int ShoppingOrderId { get; set; } // Primary Key 

        [DisplayName("User Name")]
        [StringLength(50)] // Ensures UserName Property doesn't exceed 50 Characters
        [Required]
        [DataType(DataType.Text)]
        public string UserName { get; set; } // Foreign Key to Customers Table
         
        [DisplayName("First Name")] // Displays the custom 'First Name' instead of property name
        [Required]
        public string ShoppingFirstName { get; set; } // Customer First Name Property

        [Required]
        [DisplayName("Order Date")]
        [DataType(DataType.Date)] // Date Validation: Client Side Validation 
        public DateTime Orderdate { get; set; } // Order Date Property 

        public ShoppingOrder()
        {
            Orderdate = DateTime.Now; // Initialises new payment by setting 'PayDate' to current date and time the payment was created
        }

        [Required]
        [DisplayName("Total Price")]
        [Range(1, 500000)] // Allows the input of Minimum Total Price of 1 dollar and Maximum Total Price of 500 thousand dollars and any price in between
        [RegularExpression("^(?!0\\.00$)([1-9]\\d{0,5}(\\.\\d{1,2})?)$", ErrorMessage = "Please enter a Valid Amount")]
        // RegEx doesn't allow $0.00, allows non-zero starting digit (1-9) with a max of 5 digits following and 1 or 2 d.p.
        [DataType(DataType.Currency)] // Represents currency value and displays currency symbol
        public decimal Totalprice { get; set; } // Total Price Property


        [Required]
        [DisplayName("Items in Cart")] // Displays the custom 'Items in Cart' instead of property name
        [RegularExpression("^\\d+$", ErrorMessage = "Please enter a valid Quantity Amount")]
        // RegEx for a Positive Integer Value. As a quantity amount cannot be negative.
        public int CartQuantity { get; set; } // Cart Quantity Property


        public ICollection<Payment> Payment { get; set; } // Reference navigation to dependent; One to Many Relationship: Multiple payments Associated w/ One Shopping Order.
        public ICollection<ShoppingItem> ShoppingItems { get; set; } // One to Many Relationship: One Shopping Order Associated w/ Many Shopping Items


    }
} 