using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using ChronoMarketplace.Areas.Identity.Data;
using ChronoMarketplace.Models;

namespace ChronoMarketplace.Models
{
   public class ShoppingItem
    {
       [Key] 
        public int ShoppingItemId { get; set; } //Primary Key
        public int ShoppingOrderId { get; set; } //Foreign Key to Shopping Orders Table


        [DisplayName("Product ID")]
        [Required]
        public int ProductId { get; set; } //Foreign Key to Products Table

        [DisplayName("Product Quantity")]
        [Required]
        public int Quantity { get; set; }

        [Required]
        [DisplayName("Total Price")]
        public int Totalprice { get; set; }

        public Product Product { get; set; } // One to Many Relationship: One Product Associated w/ Many Shopping Items
        public ShoppingOrder ShoppingOrder { get; set; } // One to Many Relationship: One Shopping Order Associated w/ Many Shopping Items
    }
}

