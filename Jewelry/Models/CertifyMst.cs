using System.ComponentModel.DataAnnotations;

namespace Jewelry.Models
{
    public class CertifyMst
    {
        [Key]
        public int CertifyMstID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Certification")]
        public string Cat_Name { get; set; }



    }
}
