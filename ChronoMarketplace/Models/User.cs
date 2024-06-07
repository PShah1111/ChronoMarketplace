using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ChronoMarketplace.Models
{
    public class User
    {
        [Key] public int User_ID { get; set; }

        [Required]
        [DisplayName("First Name")]
        public string? U_firstname { get; set; }

        [Required]
        [DisplayName("Last Name")]
        public string? U_lastname { get; set; }

        [Required]
        [DisplayName("Street")]
        public string? U_street { get; set; }

        [Required]
        [DisplayName("City")]
        public string? U_city { get; set; }

        [Required]
        [DisplayName("Zip")]
        public string? U_zip { get; set; }

        [Required]
        [DisplayName("Contact Number")]
        [RegularExpression("((^\\([0]\\d{1}\\))(\\d{7}$)|(^\\([0][2]\\d{1}\\))(\\d{6,8}$)|([0][8][0][0])([\\s])(\\d{5,8}$))", ErrorMessage = "Please enter a valid phone number")]
        public string? U_contactnumber { get; set; }

        [Required]
        [DisplayName("Date Of Birth")]
        [DataType(DataType.Date)]
        public string U_DOB { get; set; }


        public ICollection<Shopping_Cart> Shopping_Carts { get; set; }
        public ICollection<Shopping_Order> Shopping_Orders { get; set; }
        public ICollection<Payment> Payments { get; set; }





    }
}
