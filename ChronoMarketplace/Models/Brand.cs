using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ChronoMarketplace.Models
{
    public class Brand
    {
        public int BrandId { get; set; } //Primary Key
        [DisplayName ("Brand Name")]
        [StringLength(50)]

        public string BrandName { get; set; }

        public ICollection<Product> Products { get; set; } //One to Many Relationship: Many Products Associated w/ One Brand


    }
}


