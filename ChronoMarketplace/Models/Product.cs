using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ChronoMarketplace.Models
{
    public class Product
    {

        [Key] public int ProductId { get; set; }

        [Required]
        [DisplayName("Category ID")]
        public int CategoryId { get; set; }

        [Required]
        [DisplayName("Product Image")]
        public string Pimage { get; set; }

        [Required]
        [DisplayName("Product Name")]
        public string? Pname { get; set; }

        [Required]
        [DisplayName("Product Price")]
        public int Pprice { get; set; }

        [Required]
        [DisplayName("Product Stock")]
        public int Pstock { get; set; }



        public Category Category  { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
    }
}
