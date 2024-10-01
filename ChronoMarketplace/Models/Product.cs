using ChronoMarketplace.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChronoMarketplace.Models
{
    public class Product
    {
        [DisplayName("Product ID")]
        [Required]
        [StringLength(50)]
        public int ProductId { get; set; } //Primary Key

        [DisplayName("Brand ID")]
        [Required]
        [StringLength(50)]
        public int BrandId { get; set; } //Foreign Key to Brands Table

        [DisplayName("Upload Image")]
        [Required]
        [NotMapped]
         
        public IFormFile Pimage { get; set; }
       

        [DisplayName("Product Name")]
        [Required]
        [StringLength(50)]
        public string Pname { get; set; }

        [Required]
        [DisplayName("Product Price")]
        [Range(0, 100000)]
        [DataType(DataType.Currency)]
        public int Pprice { get; set; }

        [Required]
        [DisplayName("Special Price")]
        [Range(0, 100000)]
        [DataType(DataType.Currency)]
        public int SpecialPrice { get; set; }

        [DisplayName("Stock")]
        [Required]
        public int Pstock { get; set; }



        public Brand Brand { get; set; }
        public ICollection<ShoppingItem> ShoppingItems { get; set; } //One to Many Relationship: One Product Associated w/ Many Shopping Items
    }
}

