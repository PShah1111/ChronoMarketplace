using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ChronoMarketplace.Models
{
    public class Category
    {
        [Key] public int Category_ID { get; set; }

        [Required]
        [DisplayName("Category Name")]
        public string Category_Name { get; set; }

        public ICollection<Product> Products { get; set; }


    }
}
