using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ChronoMarketplace.Models
{
    public class User
    {
        public int user_ID { get; set; }

        [Required]
        [DisplayName("First Name")]
        public string u_firstname { get; set; }

        [Required]
        [DisplayName("Last Name")]
        public string u_lastname { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string u_street { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string u_city { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string u_zip { get; set; }

        [Required]
        [DisplayName("Contact Number")]
        [RegularExpression("((^\\([0]\\d{1}\\))(\\d{7}$)|(^\\([0][2]\\d{1}\\))(\\d{6,8}$)|([0][8][0][0])([\\s])(\\d{5,8}$))", ErrorMessage = "Please enter a valid phone number")]
        public string u_contactnumber { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public string u_DOB { get; set; }


        public ICollection<Staff> Staffs { get; set; }
        public ICollection<Appointment> Appointments { get; set; }





    }
}
