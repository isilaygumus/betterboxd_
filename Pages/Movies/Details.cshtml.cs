using betterboxd_web.Data;
using betterboxd_web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace betterboxd_web.Pages.Movies;

public class DetailsModel : PageModel
{
    private readonly BetterboxdContext _context;

    public DetailsModel(BetterboxdContext context) => _context = context;

    public Movie Movie { get; set; } = null!;
    public List<Movie> RelatedMovies { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var movie = await _context.Movies
            .Include(m => m.Genre)
            .FirstOrDefaultAsync(m => m.Id == id);

        if (movie is null) return NotFound();

        Movie = movie;

        // Aynı türden en yüksek puanlı 6 film
        RelatedMovies = await _context.Movies
            .Where(m => m.GenreId == movie.GenreId && m.Id != movie.Id)
            .OrderByDescending(m => m.Rating)
            .Take(6)
            .ToListAsync();

        return Page();
    }
}