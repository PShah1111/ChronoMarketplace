using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ChronoMarketplace.Models
{
    public class Categories
    {
        [Required]
        [DisplayName("Category ID")]
        public int Category_ID { get; set; }

        [Required]
        [DisplayName("Category Name")]
        public string Category_Name { get; set; }

        public ICollection<Products>? Products { get; set; }


    }
}
