using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace betterboxd_web.Pages
{
    public class ProfilModel : PageModel
    {
        

        [BindProperty]
        public string Username { get; set; } = "Kullanıcı Adı";

        [BindProperty]
        public string Bio { get; set; } = "";

        public List<string> FavoriteMovies { get; set; } = new();

        public void OnGet()
        {
            
        }
    }
}