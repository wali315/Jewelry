using System.ComponentModel.DataAnnotations;

namespace Jewelry.Models
{
    public class ProdMst
    {

        [Key]
        public int ProdMstID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Type Of Product")]
        public string Prod_Type { get; set; }



    }
}
