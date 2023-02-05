using System.ComponentModel.DataAnnotations;

namespace FreshFarmMarket.Models
{
    public class RegisterUser
    {
        [Required, MinLength(3, ErrorMessage = "Name must be longer than 3 characters")]
        [Display(Name = "Full Name")]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.CreditCard)]
        [Display(Name = "Credit Card Number")]
        public string CreditCardNo { get; set; } = string.Empty;

        [Required, MaxLength(1)]
        [Display(Name = "Gender")]
        public string Gender { get; set; } = string.Empty;

        [Required, MinLength(3, ErrorMessage = "Name must be longer than 3 characters")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Mobile Number")]
        public string MobileNo { get; set; } = string.Empty;

        [Required, MinLength(3, ErrorMessage = "Name must be longer than 3 characters")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Delivery Address")]
        public string DeliveryAddress { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required, MinLength(3, ErrorMessage = "Name must be longer than 3 characters")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Password does not match")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        [Required, MinLength(3, ErrorMessage = "Name must be longer than 3 characters")]
        [DataType(DataType.Upload)]
        [Display(Name = "Photo")]
        public string Photo { get; set; } = string.Empty;

        [Required, MinLength(3, ErrorMessage = "Name must be longer than 3 characters")]
        [Display(Name = "About Me")]
        public string AboutMe { get; set; } = string.Empty;
    }
}
