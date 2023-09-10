using System.ComponentModel.DataAnnotations;

namespace Jewelry.Models
{
    public class BrandMst
    {
        [Key]
        public int BrandMstID { get; set; }

        [Required] 
        [StringLength(50)]
        [Display(Name = "Type Of Brand")]
        public string Brand_Type { get; set; }


    }
}
