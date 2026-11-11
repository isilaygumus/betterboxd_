using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace betterboxd_web.Pages
{
    public class ProfilModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        public ProfilModel(SignInManager<IdentityUser> signInManager)
            => _signInManager = signInManager;
        

        [BindProperty]
        public string Username { get; set; } = string.Empty;

        [BindProperty]
        public string Bio { get; set; } = "";

        public List<string> FavoriteMovies { get; set; } = new();

        public void OnGet()
        {
            Username = User.Identity?.Name ?? string.Empty;
        }

        public async Task<IActionResult> OnPostLogoutAsync()
        {
            await _signInManager.SignOutAsync();
            return RedirectToPage("/Index");
        }
    }
}