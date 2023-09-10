using System.ComponentModel.DataAnnotations;

namespace Jewelry.Models
{
    public class CatMst
    {
        [Key]
        public int CatMstId { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Name Of Category")]
        public string Cat_Name { get; set; }

        
    }
}
