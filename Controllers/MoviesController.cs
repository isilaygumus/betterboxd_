using System.Linq.Expressions;
using betterboxd_web.Dtos;
using betterboxd_web.Models;
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

    // Movie -> MovieDto dönüşümü tek yerde dursun
    private static readonly Expression<Func<Movie, MovieDto>> ToDto = m => new MovieDto
    {
        Id = m.Id,
        Title = m.Title,
        Director = m.Director,
        Year = m.Year,
        Rating = m.Rating,
        PosterUrl = m.PosterUrl,
        Genre = m.Genre.Ad
    };


    [HttpGet]
    public async Task<ActionResult<List<MovieDto>>> GetAll([FromQuery] int? genreId)
    {
        var query = _context.Movies.AsQueryable();

        if (genreId.HasValue)
            query = query.Where(m => m.GenreId == genreId.Value);

        // ARAMA: ?search= filtresi burada, genreId'den hemen sonra eklenecek
        // (üçüncü kişinin görevi)

        return await query.OrderBy(m => m.Id).Select(ToDto).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<MovieDto>> GetById(int id)
    {
        var movie = await _context.Movies
            .Where(m => m.Id == id)
            .Select(ToDto)
            .FirstOrDefaultAsync();

        return movie is null ? NotFound() : movie;
    }
    // POST /api/movies
    // TODO: [Authorize(Roles = "Admin")] (JWT hazır olunca)
    [HttpPost]
    public async Task<ActionResult<MovieDto>> Create(MovieSaveDto dto)
    {
        if (!await _context.Genres.AnyAsync(g => g.Id == dto.GenreId))
            return BadRequest(new { error = $"GenreId {dto.GenreId} bulunamadı." });

        var movie = new Movie
        {
            Title = dto.Title,
            Director = dto.Director,
            Year = dto.Year,
            Rating = dto.Rating,
            PosterUrl = dto.PosterUrl,
            GenreId = dto.GenreId,
            AddedDate = DateTime.UtcNow
        };
        _context.Movies.Add(movie);
        await _context.SaveChangesAsync();

        var created = await _context.Movies
            .Where(m => m.Id == movie.Id)
            .Select(ToDto)
            .FirstAsync();

        return CreatedAtAction(nameof(GetById), new { id = movie.Id }, created);
    }
    // PUT /api/movies/5
    // TODO: [Authorize(Roles = "Admin")]
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, MovieSaveDto dto)
    {
        var movie = await _context.Movies.FindAsync(id);
        if (movie is null) return NotFound();

        if (!await _context.Genres.AnyAsync(g => g.Id == dto.GenreId))
            return BadRequest(new { error = $"GenreId {dto.GenreId} bulunamadı." });

        movie.Title = dto.Title;
        movie.Director = dto.Director;
        movie.Year = dto.Year;
        movie.Rating = dto.Rating;
        movie.PosterUrl = dto.PosterUrl;
        movie.GenreId = dto.GenreId;

        await _context.SaveChangesAsync();
        return NoContent();
    }

    // DELETE /api/movies/5
    // TODO: [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var movie = await _context.Movies.FindAsync(id);
        if (movie is null) return NotFound();

        _context.Movies.Remove(movie);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
