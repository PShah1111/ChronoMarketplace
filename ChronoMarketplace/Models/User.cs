using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ChronoMarketplace.Models
{
    public class User
    {
        [Key] public int UserId { get; set; }

        [Required]
        [DisplayName("First Name")]
        public string? Ufirstname { get; set; }

        [Required]
        [DisplayName("Last Name")]
        public string? Ulastname { get; set; }

        [Required]
        [DisplayName("Street")]
        public string? Ustreet { get; set; }

        [Required]
        [DisplayName("City")]
        public string? Ucity { get; set; }

        [Required]
        [DisplayName("Zip")]
        public string? Uzip { get; set; }

        [Required]
        [DisplayName("Contact Number")]
        [RegularExpression("((^\\([0]\\d{1}\\))(\\d{7}$)|(^\\([0][2]\\d{1}\\))(\\d{6,8}$)|([0][8][0][0])([\\s])(\\d{5,8}$))", ErrorMessage = "Please enter a valid phone number")]
        public string? Ucontactnumber { get; set; }

        [Required]
        [DisplayName("Date Of Birth")]
        [DataType(DataType.Date)]
        public string UDOB { get; set; }


        public ICollection<ShoppingCart> ShoppingCarts { get; set; }
        public ICollection<ShoppingOrder> ShoppingOrders { get; set; }
        public ICollection<Payment> Payments { get; set; }





    }
}
