using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Jewelry.Models
{
    public class UserRegMst
    {
        [Key]
        public int UserRegMstId { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Frist Name")]
        public string userFname { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Last Name")]
        public string userLname { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Address")]
        public string address { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "City")]
        public string city { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "State")]
        public string state { get; set; }

        [Required]
        [Display(Name = "Mobile Number")]
        [MaxLength(15, ErrorMessage = "Max 15 character Required"), MinLength(11, ErrorMessage = "Minimun 12 character Required")]
        public string mobNo { get; set; }

        [Required]
        [Display(Name = "Email ID")]
        [DataType(DataType.EmailAddress)]
        [MaxLength(40, ErrorMessage = "Max 40 character Required"), MinLength(8, ErrorMessage = "Minimun 8 character Required")]
        public string emailID { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        
        public DateTime dob { get; set; }

        [Required]
        public DateTime cdate { get; set; } = DateTime.Now.Date;

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [MaxLength(15, ErrorMessage = "Max 15 character Required"), MinLength(6, ErrorMessage = "Minimun 6 character Required")]
        public string password { get; set; }
    }
}
