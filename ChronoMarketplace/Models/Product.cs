using ChronoMarketplace.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChronoMarketplace.Models
{
    public class Product
    {
        [DisplayName("Product ID")]
        [Required]
        public int ProductId { get; set; } // Primary Key


        [DisplayName("Brand ID")] 
        [Required]
        public int BrandId { get; set; } // Foreign Key to Brands Table 


        [DisplayName("Image Name")] 
        [StringLength(50)] // Ensures ImageName Property doesn't exceed 50 Characters
        public string ImageName { get; set; } // Image Name Property


        [DisplayName("Upload Image:")] // Displays the custom 'Upload Image:' instead of property name
        [Required(ErrorMessage = "Please enter a product image")]
        [NotMapped] // Does not store Product Image Property in DB
        public IFormFile PImage { get; set; } // Product Image Property


        [DisplayName("Product Name")] // Displays the custom 'Product Name' instead of property name
        [Required]
        [RegularExpression("^([ \u00c0-\u01ffa-zA-Z'0-9]{1,60})$", ErrorMessage = "Please enter a valid product name")]
        // Regular Expression: Client Side Validation, RegEx Allows for Letters A-Z including accented letters, numbers, apostrophes, spaces
        // RegEx: Product Name can be from 1 to 60 characters long
        public string PName { get; set; } // Product Name Property


        [DisplayName("Product Description")] // Displays the custom 'Product Description' instead of property name
        [Required]
        [RegularExpression("^([ À-ǿa-zA-Z'0-9,\\-.]{1,300})$", ErrorMessage = "Please enter a valid description")]
        // Regular Expression: Client Side Validation, RegEx Allows for Letters A-Z including accented letters, numbers, apostrophes, spaces, commas, hyphens and full stops.
        // RegEx: Product Description can be from 1 to 300 characters long
        public string PDescription { get; set; } // Product Description Property


        [Required]
        [DisplayName("Product Price")] // Displays the custom 'Product Price' instead of property name
        [Range(1, 90000)] // Allows the input of Minimum Product Price of 1 dollar and Maximum Product Price of 90 thousand dollars and any price in between
        [DataType(DataType.Currency)] // Represents currency value and displays currency symbol
        [RegularExpression("^(?!0\\.00$)([1-9]\\d{0,4}(\\.\\d{1,2})?)$", ErrorMessage = "Please enter a valid amount")]
        // RegEx doesn't allow $0.00, allows non-zero starting digit (1-9) with a max of 4 digits following and 1 or 2 d.p.
        public decimal PPrice { get; set; } // Product Price Property



        public Brand Brand { get; set; }
        public ICollection<ShoppingItem> ShoppingItems { get; set; } // One to Many Relationship: One Product Associated w/ Many Shopping Items
    }
}

