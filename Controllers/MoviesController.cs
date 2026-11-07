using betterboxd_web.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace betterboxd_web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MoviesController : ControllerBase
{
    private readonly BetterboxdContext _context;

    public MoviesController(BetterboxdContext context) => _context = context;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var movies = await _context.Movies
            .Select(m => new
            {
                m.Id,
                m.Title,
                m.Director,
                m.Year,
                m.Rating,
                m.PosterUrl,
                Genre = m.Genre.Ad
            })
            .ToListAsync();

        return Ok(movies);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var movie = await _context.Movies
            .Where(m => m.Id == id)
            .Select(m => new
            {
                m.Id,
                m.Title,
                m.Director,
                m.Year,
                m.Rating,
                m.PosterUrl,
                Genre = m.Genre.Ad
            })
            .FirstOrDefaultAsync();

        return movie is null ? NotFound() : Ok(movie);
    }
}