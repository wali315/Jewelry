using System.ComponentModel.DataAnnotations;

namespace Jewelry.Models
{
    public class GoldKrtMst
    {
        [Key]
        public int GoldKrtMstID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Carat Of Gold")]
        public string Gold_Crt { get; set; }
    }
}
