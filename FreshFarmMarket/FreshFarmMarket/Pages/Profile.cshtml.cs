using FreshFarmMarket.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace FreshFarmMarket.Pages
{
    public class ProfileModel : PageModel
    {
        public Login LModel { get; set; }

        private UserManager<AppUser> userManager { get; }
        private SignInManager<AppUser> signInManager { get; }


        public ProfileModel(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }


    }
}