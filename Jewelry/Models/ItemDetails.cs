
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;

namespace Jewelry.Models
{
    public class ItemDetails
    {
        //------------Product Details------------------
        [Key]
        public int ItemMstID { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CatMstId { get; set; }
        public CatMst catMst { get; set; }

        [Required]
        [Display(Name = "Name of Product")]
        public string prodName { get; set; }

        [Required]
        [Display(Name = "Pairs Of Product")]
        public int Pairs { get; set; }

        [Required]
        [Display(Name = "Brand")]
        public int BrandMstID { get; set; }
        public BrandMst brandMst { get; set; }

        [Required]
        [Display(Name = "Available Quantity")]
        public int Quantity { get; set; }

        [Required]
        [Display(Name = "Certification")]
        public int CertifyMstID { get; set; }
        public CertifyMst certifyMst { get; set; }

        // <---------Product-------------->

        // <---------Gold-------------->
        [Required]
        [Display(Name = "Cart of Gold")]
        public int GoldKrtMstID { get; set; }
        public GoldKrtMst goldKrtMst { get; set; }

        [Required]
        [Display(Name = "Weight Of Gold")]
        public int Gold_Wt { get; set; }

        [Required]
        [Display(Name = "Net Gold")]
        public int Net_Gold { get; set; }

        [Required]
        [Display(Name = "Wastage In Percentage")]
        public int Wstg_Per { get; set; }

        [Required]
        [Display(Name = "Wastage")]
        public int Wstg { get; set; }

        [Required]
        [Display(Name = "Total Gross Weight")]
        public int Tot_Gross_Wt { get; set; }

        [Required]
        [Display(Name = "Rate Of Gold")]
        public int Gold_Rate { get; set; }

        [Required]
        [Display(Name = "Amount Of Gold In Item")]
        public int Gold_Amt { get; set; }

        [Required]
        [Display(Name = "Gold Making Charges")]
        public int Gold_Making { get; set; }

              

        // <---------Gold-------------->

        // <----------Dimond/Stone------->
        [Required]
        [Display(Name = "Product")]
        public int ProdMstID { get; set; }
        public ProdMst prodMst { get; set; }
        
        [Required]
        [Display(Name = "Total Pcs Of Diamond In Item")]
        public int Dim_Pcs { get; set; }

        [Required]
        [Display(Name = "Weight Of Stone/Dimond")]
        public int Stone_Wt { get; set; }

        [Required]
        [Display(Name = "Stone/Dimond Making Charges")]
        public int Stone_Making { get; set; }

        [Required]
        [Display(Name = "Total Amount Of All Diamonds In Item")]
        public int Dim_Amt { get; set; }

        // <----------Dimond/Stone------->

        //<------------Total------------->

        [Required]
        [Display(Name ="Image of Item")]
        public string imgUrl { get; set; }

        [Required]
        [Display(Name = "MRP Of Product")]
        public int MRP { get; set; }

    }
}
