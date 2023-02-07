using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace FreshFarmMarket.Models
{
    public class AppUser :IdentityUser
    {
        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.CreditCard)]
        [Display(Name = "Credit Card Number")]
        public string CreditCardNo { get; set; } = string.Empty;

        [Required, MaxLength(1)]
        [Display(Name = "Gender")]
        public string Gender { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Mobile Number")]
        public string MobileNo { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Delivery Address")]
        public string DeliveryAddress { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [MaxLength(50)]
        [Display(Name = "Photo")]
        public string Photo { get; set; } = "/uploads/user.jpg";

        [Required]
        [Display(Name = "About Me")]
        public string AboutMe { get; set; } = string.Empty;
    }
}
