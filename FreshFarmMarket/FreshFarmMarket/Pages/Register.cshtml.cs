using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FreshFarmMarket.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.DataProtection;

namespace FreshFarmMarket.Pages
{
    public class RegisterModel : PageModel
    {
        private UserManager<AppUser> userManager { get; }
        private SignInManager<AppUser> signInManager { get; }
        private readonly RoleManager<IdentityRole> roleManager; 
        private IWebHostEnvironment _environment;


        [BindProperty]
        public Register RModel { get; set; } = new Register();

        [BindProperty]
        public IFormFile? Upload { get; set; }
        public RegisterModel(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, 
             RoleManager<IdentityRole> roleManager, IWebHostEnvironment environment)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            _environment = environment;
        }

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid) 
            {
                var dataProtectionProvider = DataProtectionProvider.Create("EncryptData");
                var protector = dataProtectionProvider.CreateProtector("MySecretKey");

                if (Upload != null)
                {
                    var imageFile = Guid.NewGuid() + Path.GetExtension(Upload.FileName); ;
                    var file = Path.Combine(_environment.ContentRootPath, "wwwroot\\uploads", imageFile);
                    using var fileStream = new FileStream(file, FileMode.Create);
                    await Upload.CopyToAsync(fileStream);
                    RModel.Photo = "/uploads/" + imageFile;
                }

                var user = new AppUser()
                {
                    UserName = RModel.Email,
                    Email = RModel.Email,
                    FullName = RModel.FullName,

                    CreditCardNo = protector.Protect(RModel.CreditCardNo),
                    Gender = RModel.Gender,

                    MobileNo = RModel.MobileNo,
                    DeliveryAddress = RModel.DeliveryAddress,

                    Photo = RModel.Photo,
                    AboutMe = RModel.AboutMe

                };

                IdentityRole role = await roleManager.FindByIdAsync("Admin");
                if (role == null)
                {
                    IdentityResult result2 = await roleManager.CreateAsync(new IdentityRole("Admin"));
                    if (result2.Succeeded)
                    {
                        ModelState.AddModelError("", "Create role admin failed");
                    }
                }


                var result = await userManager.CreateAsync(user,RModel.Password);
                if (result.Succeeded)
                {
                    result = await userManager.AddToRoleAsync(user, "Admin");

                    await signInManager.SignInAsync(user, false);
                    TempData["FlashMessage.Type"] = "success";
                    TempData["FlashMessage.Text"] = string.Format("User {0} is added", user);
                    return RedirectToPage("Profile");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

            }
            return Page();
        }

    }
}
