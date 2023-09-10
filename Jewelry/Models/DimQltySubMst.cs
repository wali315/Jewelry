using System.ComponentModel.DataAnnotations;

namespace Jewelry.Models
{
    public class DimQltySubMst
    {

        [Key]
        public int DimQltySubMstID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Sub Quality Of Diamond")]
        public string DimQlty { get; set; }





    }
}
