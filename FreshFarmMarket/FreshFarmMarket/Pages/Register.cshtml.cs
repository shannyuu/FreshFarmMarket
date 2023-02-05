using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FreshFarmMarket.Models;
using Microsoft.AspNetCore.Identity;

namespace FreshFarmMarket.Pages
{
    public class RegisterModel : PageModel
    {
        private UserManager<AppUser> userManager { get; }
        private SignInManager<AppUser> signInManager { get; }
        private IWebHostEnvironment _environment;


        [BindProperty]
        public Register RModel { get; set; } = new Register();

        [BindProperty]
        public IFormFile? Upload { get; set; }
        public RegisterModel(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IWebHostEnvironment environment)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            _environment = environment;
        }

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid) {
                var user = new AppUser()
                {
                    UserName = RModel.Email,
                    Email = RModel.Email,
                    FullName = RModel.FullName,

                    CreditCardNo = RModel.CreditCardNo,
                    Gender = RModel.Gender,

                    MobileNo = RModel.MobileNo,
                    DeliveryAddress = RModel.DeliveryAddress,

                    Photo = RModel.Photo,
                    AboutMe = RModel.AboutMe

                };
                var result = await userManager.CreateAsync(user,RModel.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, false);
                    TempData["FlashMessage.Type"] = "success";
                    TempData["FlashMessage.Text"] = string.Format("User {0} is added", user);
                    return RedirectToPage("Index");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                if (Upload != null)
                {
                    if (Upload.Length > 0 * 1024 * 1024)
                    {
                        ModelState.AddModelError("Upload", "File size cannot exceed 2MB.");
                        return Page();
                    }
                    var uploadsFolder = "uploads";
                    var imageFile = Guid.NewGuid() + Path.GetExtension(Upload.FileName);
                    var imagePath = Path.Combine(_environment.ContentRootPath, "wwwroot", uploadsFolder, imageFile);
                    using var fileStream = new FileStream(imagePath, FileMode.Create);
                    await Upload.CopyToAsync(fileStream);
                    RModel.Photo = string.Format("/{0}/{1}", uploadsFolder, imageFile);
                }
            }
            return Page();
        }

    }
}
