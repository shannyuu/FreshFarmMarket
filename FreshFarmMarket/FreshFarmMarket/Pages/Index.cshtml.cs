using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FreshFarmMarket.Models;

namespace FreshFarmMarket.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IHttpContextAccessor contxt;

        public IndexModel(IHttpContextAccessor httpContextAccessor)
        {
            contxt = httpContextAccessor;
        }
        public void OnGet()
        {
        }

        public IActionResult Index()
        {
            contxt.HttpContext.Session.SetString("UserName", "user1");
            contxt.HttpContext.Session.SetInt32("UserId", 50);
            return Page();
        }
    }
}