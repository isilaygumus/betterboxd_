using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace betterboxd_web.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        public LoginModel(SignInManager<IdentityUser> signInManager,
                          UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [BindProperty]
        public InputModel Input { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public string? ReturnUrl { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "Kullanıcı adı veya e-posta zorunludur.")]
            public string UsernameOrEmail { get; set; } = string.Empty;

            [Required(ErrorMessage = "Şifre zorunludur.")]
            [DataType(DataType.Password)]
            public string Password { get; set; } = string.Empty;

            public bool RememberMe { get; set; }
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var girilen = Input.UsernameOrEmail.Trim();
            var user = girilen.Contains('@')
                ? await _userManager.FindByEmailAsync(girilen)
                : await _userManager.FindByNameAsync(girilen);

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Kullanıcı adı veya şifre hatalı.");
                return Page();
            }

            var result = await _signInManager.PasswordSignInAsync(
                user, Input.Password, Input.RememberMe, lockoutOnFailure: true);
            
            if (result.Succeeded)
            {
                if (!string.IsNullOrEmpty(ReturnUrl) && Url.IsLocalUrl(ReturnUrl))
                    return LocalRedirect(ReturnUrl);

                return RedirectToPage("/Profil");
            }

            if (result.IsLockedOut)
            {
                ModelState.AddModelError(string.Empty, "Çok fazla deneme yapıldı lütfen birkaç dakika sonra tekrar deneyin.");
                return Page();
            }

            ModelState.AddModelError(string.Empty, "Kullanıcı adı veya şifresi hatalı.");
            return Page();

        }
    }
}