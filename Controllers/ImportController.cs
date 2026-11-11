using betterboxd_web.Data;
using betterboxd_web.Models;
using betterboxd_web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace betterboxd_web.Controllers;

[ApiController]
[Route("api/admin/import")]
public class ImportController : ControllerBase
{
    private readonly BetterboxdContext _context;
    private readonly TmdbService _tmdb;

    public ImportController(BetterboxdContext context, TmdbService tmdb)
    {
        _context = context;
        _tmdb = tmdb;
    }

    // POST /api/admin/import/tmdb?pages=3  (sayfa başına 20 film)
    // TODO: [Authorize(Roles = "Admin")] (JWT hazır olunca)
    [HttpPost("tmdb")]
    public async Task<IActionResult> ImportFromTmdb([FromQuery] int pages = 1)
    {
        pages = Math.Clamp(pages, 1, 10);
        var tmdbGenres = (await _tmdb.GetGenresAsync()).ToDictionary(g => g.Id, g => g.Name);
        int added = 0, skipped = 0;

        for (int page = 1; page <= pages; page++)
        {
            foreach (var t in await _tmdb.GetPopularAsync(page))
            {
                if (string.IsNullOrWhiteSpace(t.Title) || t.PosterPath is null ||
                    t.ReleaseDate is null || t.ReleaseDate.Length < 4 ||
                    !int.TryParse(t.ReleaseDate[..4], out var year))
                {
                    skipped++;
                    continue;
                }

                var title = Trunc(t.Title, 150);

                // Aynı ad ve yıl varsa tekrar ekleme
                if (await _context.Movies.AnyAsync(m => m.Title == title && m.Year == year))
                {
                    skipped++;
                    continue;
                }

                // TMDB'de bir filmin birden çok türü var, bizde tek tür: ilkini al
                var genreName = t.GenreIds
                    .Select(id => tmdbGenres.GetValueOrDefault(id))
                    .FirstOrDefault(n => n != null) ?? "Diğer";

                var genre = await _context.Genres.FirstOrDefaultAsync(g => g.Ad == genreName);
                if (genre is null)
                {
                    genre = new Genre { Ad = Trunc(genreName, 50) };
                    _context.Genres.Add(genre);
                    await _context.SaveChangesAsync();
                }

                var director = await _tmdb.GetDirectorAsync(t.Id) ?? "Bilinmiyor";

                _context.Movies.Add(new Movie
                {
                    Title = title,
                    Director = Trunc(director, 100),
                    Year = year,
                    Rating = Math.Round((decimal)t.VoteAverage / 2m, 1), // TMDB 10 üzerinden, biz 5 üzerinden
                    PosterUrl = $"https://image.tmdb.org/t/p/w342{t.PosterPath}",
                    GenreId = genre.Id,
                    AddedDate = DateTime.UtcNow
                });
                added++;
            }
            await _context.SaveChangesAsync();
        }

        return Ok(new { added, skipped });
    }

    private static string Trunc(string s, int max) => s.Length <= max ? s : s[..max];
}