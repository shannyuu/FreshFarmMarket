using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FreshFarmMarket.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using AspNetCore.ReCaptcha;

namespace FreshFarmMarket.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Login LModel { get; set; }

        private readonly SignInManager<AppUser> signInManager;
        private readonly UserManager<AppUser> userManager;

        public LoginModel(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }
        public void OnGet()
        {
        }
        [ValidateReCaptcha]
        [HttpPost]
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = await userManager.FindByEmailAsync(LModel.Email);
                if (appUser == null)
                {
                    await signInManager.SignOutAsync();
                    var identityResult = await signInManager.PasswordSignInAsync(LModel.Email, LModel.Password, LModel.RememberMe, false);
                    if (identityResult.Succeeded)
                    {
                        TempData["FlashMessage.Type"] = "success";
                        TempData["FlashMessage.Text"] = string.Format("Login successful");
                        return RedirectToPage("Profile");
                        
                    }
                    if (identityResult.IsLockedOut)
                            ModelState.AddModelError("", "Your account is locked out. Kindly wait for 10 minutes and try again");
                }
                ModelState.AddModelError("", "Email or Password incorrect");
            }
            return Page();
        }

    }
}
