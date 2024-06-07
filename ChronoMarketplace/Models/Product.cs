using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ChronoMarketplace.Models
{
    public class Product
    {

        [Key] public int Product_ID { get; set; }

        [Required]
        [DisplayName("Category ID")]
        public int Category_ID { get; set; }

        [Required]
        [DisplayName("Product Image")]
        public string P_image { get; set; }

        [Required]
        [DisplayName("Product Name")]
        public string? P_name { get; set; }

        [Required]
        [DisplayName("Product Price")]
        public int P_price { get; set; }

        [Required]
        [DisplayName("Product Stock")]
        public int P_stock { get; set; }



        public Category Category  { get; set; }
        public Shopping_Cart Shopping_Cart { get; set; }
    }
}
