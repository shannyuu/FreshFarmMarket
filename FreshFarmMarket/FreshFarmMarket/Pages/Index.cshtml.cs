using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FreshFarmMarket.Models;

namespace FreshFarmMarket.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public RegisterUser MyUser { get; set; } = new();
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