using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ChronoMarketplace.Models
{
    public class Categories
    {
        [Required]
        [DisplayName("Category ID")]
        public int category_ID { get; set; }

        [Required]
        [DisplayName("Category Name")]
        public string category_name { get; set; }


    }
}
