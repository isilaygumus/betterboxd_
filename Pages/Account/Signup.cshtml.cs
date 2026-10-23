using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace betterboxd_web.Pages.Account
{
    public class SignupModel : PageModel
    {
        [BindProperty]
        public InputModel Input { get; set; } = new();

        public class InputModel
        {
            [Required(ErrorMessage = "Kullanıcı adı zorunludur.")]
            public string Username { get; set; } = string.Empty;

            [Required(ErrorMessage = "E-posta zorunludur.")]
            public string Email { get; set; } = string.Empty;


            [Required(ErrorMessage = "Şifre zorunludur.")]
            [DataType(DataType.Password)]
            public string Password { get; set; } = string.Empty;

            public bool RememberMe { get; set; }
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // 1. Hafta geçici yönlendirmesi (Veritabanı/Identity 3. haftada eklenecek)
            return RedirectToPage("/Index");
        }
    }
}