using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using ChronoMarketplace.Areas.Identity.Data;
using ChronoMarketplace.Models;

namespace ChronoMarketplace.Models
{
   public class ShoppingItem
    {
       [Key]
        [Required]
        [DisplayName("Shopping Item ID")]
        public int ShoppingItemId { get; set; } // Primary Key

        [Required]
        [DisplayName("Shopping Order ID")]
        public int ShoppingOrderId { get; set; } // Foreign Key to Shopping Orders Table

        [DisplayName("Product ID")] 
        [Required]
        public int ProductId { get; set; } //Foreign Key to Products Table

        [DisplayName("Product Quantity")] // Displays the custom 'Product Quantity' instead of property name
        [Required]
        [RegularExpression("^\\d+$", ErrorMessage = "Please enter a valid Quantity Amount")] 
        // RegEx for a Positive Integer Value. As a quantity amount cannot be negative.
        public int Quantity { get; set; } // Quantity Property

   

        public Product Product { get; set; } // One to Many Relationship: One Product Associated w/ Many Shopping Items
        public ShoppingOrder ShoppingOrder { get; set; } // One to Many Relationship: One Shopping Order Associated w/ Many Shopping Items
    }
}

