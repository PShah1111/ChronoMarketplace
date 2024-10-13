using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ChronoMarketplace.Models
{
    public class Brand
    {
        [Required]
        [DisplayName("Brand ID")]
        public int BrandId { get; set; } //Primary Key

        [Required]
        [DisplayName ("Brand Name")] 
        [StringLength(50)] // Ensures BrandName Property doesn't exceed 50 Characters
  
        public string BrandName { get; set; } // Brand Name Property

        public ICollection<Product> Products { get; set; } // One to Many Relationship: Many Products Associated w/ One Brand


    }
}


