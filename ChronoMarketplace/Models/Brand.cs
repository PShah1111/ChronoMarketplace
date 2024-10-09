using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ChronoMarketplace.Models
{
    public class Brand
    {
        public int BrandId { get; set; } //Primary Key

        [DisplayName ("Brand Name")] // Displays the custom 'Brand Name' instead of property name
        [StringLength(50)] // Ensures BrandName Property doesn't exceed 50 Characters
        public string BrandName { get; set; } // Brand Name Property

        public ICollection<Product> Products { get; set; } //One to Many Relationship: Many Products Associated w/ One Brand


    }
}


