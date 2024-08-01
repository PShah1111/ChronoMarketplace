using ChronoMarketplace.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ChronoMarketplace.Models
{
    public class Product
    {

        public int ProductId { get; set; } //Primary Key

        [DisplayName("Brand Name")]
        [Required]
        public int BrandId { get; set; } //Foreign Key to Brands Table

        [DisplayName("Product Image")]
        [Required]
        public string Pimage { get; set; }

        [DisplayName("Product Name")]
        [Required]
        public string Pname { get; set; }

        [Required]
        [DisplayName("Product Price")]
        public int Pprice { get; set; }

        [Required]
        [DisplayName("Special Price")]
        public int SpecialPrice { get; set; }

        [DisplayName("Stock")]
        [Required]
        public int Pstock { get; set; }



        public Brand Brand { get; set; }
        public ICollection<ShoppingItem> ShoppingItems { get; set; } //One to Many Relationship: One Product Associated w/ Many Shopping Items
    }
}

