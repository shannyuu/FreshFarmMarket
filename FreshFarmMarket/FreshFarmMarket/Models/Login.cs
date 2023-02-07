using System.ComponentModel.DataAnnotations;

namespace FreshFarmMarket.Models
{
    public class Login
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }

        //public string CaptchaToken { get; set; }
    }
}
