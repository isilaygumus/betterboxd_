using betterboxd_web.Data;
using betterboxd_web.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace betterboxd_web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly BetterboxdContext _context;

        // DbContext yapıcı metot ile (dependency injection) alınır
        public IndexModel(BetterboxdContext context)
        {
            _context = context;
        }

        // Sayfada gösterilecek listeler
        public List<Movie> Filmler { get; set; } = new();
        public List<Movie> SonEklenenler { get; set; } = new();
        public List<Movie> EnYuksekPuanlilar { get; set; } = new();
        public int ToplamFilmSayisi { get; set; }

        public async Task OnGetAsync()
        {
            // Toplam film sayısı
            ToplamFilmSayisi = await _context.Filmler.CountAsync();

            // Son eklenen 6 film
            SonEklenenler = await _context.Filmler
                .OrderByDescending(f => f.AddedDate)
                .Take(6)
                .ToListAsync();

            // En yüksek puanlı 6 film
            EnYuksekPuanlilar = await _context.Filmler
                .OrderByDescending(f => f.Rating)
                .Take(6)
                .ToListAsync();

            // Tüm filmler, ada göre sıralı
            Filmler = await _context.Filmler
                .OrderBy(f => f.Title)
                .ToListAsync();
        }
    }
}
