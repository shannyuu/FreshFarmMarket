using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FreshFarmMarket.Pages
{
    public class LoginModel : PageModel
    {
        public LoginUser MyUser { get; set; } = new();

        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                return Redirect("/");
            }
            return Page();
        }

    }
}
