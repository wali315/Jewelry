using System.ComponentModel.DataAnnotations;

namespace Jewelry.Models
{
    public class StoneQltyMst
    {

        [Key]
        public int StoneQltyMstID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Quality Of Stone")]
        public string StoneQlty { get; set; }




    }
}
