using System.ComponentModel.DataAnnotations;

namespace FreshFarmMarket.Models
{
    public class LoginUser
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required, MinLength(3, ErrorMessage = "Name must be longer than 3 characters")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

    }
}
