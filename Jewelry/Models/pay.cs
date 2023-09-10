using System.ComponentModel.DataAnnotations;


namespace Jewelry.Models
{
    public class pay
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Total Amount")]
        public double TotalAmount { get; set; }

        [Required]
        [Display(Name = "Card Horlder Name")]
        public string Cardholdername { get; set; }

        [Required]
        [Display(Name = "Credit Card Number")]
        [MaxLength(16, ErrorMessage = "Max 16 characters required")]
        [MinLength(16, ErrorMessage = "Minimum 16 characters required")]
        public string CreditCard { get; set; }

        [Display(Name = "Expiry Date")]
        public class ExpiryDate
        {
            [Required]
            [Range(1, 12, ErrorMessage = "Invalid month")]
            public int Month { get; set; }

            [Required]
            [Range(2000, 2099, ErrorMessage = "Invalid year")]
            public int Year { get; set; }

            public DateTime ToDateTime()
            {
                return new DateTime(Year, Month, 1);
            }
        }



        [Required]
        [MaxLength(3, ErrorMessage = "Max 3 characters required")]
        [MinLength(3, ErrorMessage = "Minimum 3 characters required")]
        public string CVV { get; set; }


        [Required]
        public string Address { get; set; }

        public DateTime DateTime { get; set; } = DateTime.UtcNow;
    }
}
