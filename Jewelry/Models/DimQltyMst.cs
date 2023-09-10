using System.ComponentModel.DataAnnotations;

namespace Jewelry.Models
{
    public class DimQltyMst
    {
        [Key]
        public int DimQltyMstID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Quality Of Diamond")]
        public string DimQlty { get; set; }


    }
}
