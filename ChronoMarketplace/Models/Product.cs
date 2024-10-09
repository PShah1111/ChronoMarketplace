using ChronoMarketplace.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChronoMarketplace.Models
{
    public class Product
    {
        [DisplayName("Product ID")] // Displays the custom 'Product ID' instead of property name
        [Required]
        [StringLength(50)] // Ensures ProductId Property doesn't exceed 50 Characters
        public int ProductId { get; set; } // Primary Key


        [DisplayName("Brand ID")] // Displays the custom 'Brand ID' instead of property name
        [Required]
        [StringLength(50)] // Ensures BrandId Property doesn't exceed 50 Characters
        public int BrandId { get; set; } // Foreign Key to Brands Table 


        [DisplayName("Image Name")] // Displays the custom 'Image Name' instead of property name
        [StringLength(50)] // Ensures ImageName Property doesn't exceed 50 Characters
        public string ImageName { get; set; } // Image Name Property


        [DisplayName("Upload Image:")] // Displays the custom 'Upload Image:' instead of property name
        [Required]
        [NotMapped] // Does not store Product Image Property in DB
        public IFormFile PImage { get; set; } // Product Image Property


        [DisplayName("Product Name")] // Displays the custom 'Product Name' instead of property name
        [Required]
        [StringLength(200)] // Ensures PName Property doesn't exceed 200 Characters
        [RegularExpression("/^[\\p{Letter}\\s\\-.']+$/u", ErrorMessage = "Please enter a valid name")]
        // Regular Expression: Client Side Validation, RegEx Allows for Letters A-Z and from various other langauges
        public string PName { get; set; } // Product Name Property


        [DisplayName("Product Description")] // Displays the custom 'Product Description' instead of property name
        [Required]
        [RegularExpression("^[\\p{Letter}\\p{Number}\\p{Punctuation}\\p{Symbol}\\s]{2,500}$", ErrorMessage = "Please enter a valid description")]
        // Regular Expression: Client Side Validation
        // RegEx Allows for Letters from Various Languages, numeric characters 0-9, punctuation marks, symbols, spaces and minimum character length of 2 and does not exceed 500 characters
        public string PDescription { get; set; } // Product Description Property


        [Required]
        [DisplayName("Product Price")] // Displays the custom 'Product Price' instead of property name
        [Range(500, 90000)] // Allows the input of Minimum Product Price of 500 dollars and Maximum Product Price of 90 thousand dollars and any price in between
        [DataType(DataType.Currency)]
        public decimal PPrice { get; set; } // Product Price Property



        public Brand Brand { get; set; }
        public ICollection<ShoppingItem> ShoppingItems { get; set; } // One to Many Relationship: One Product Associated w/ Many Shopping Items
    }
}

