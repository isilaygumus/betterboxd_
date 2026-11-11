using System.Linq.Expressions;
using betterboxd_web.Data;
using betterboxd_web.Dtos;
using betterboxd_web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace betterboxd_web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GenresController : ControllerBase
{
    private readonly BetterboxdContext _context;

    public GenresController(BetterboxdContext context) => _context = context;

    private static readonly Expression<Func<Genre, GenreDto>> ToDto = g => new GenreDto
    {
        Id = g.Id,
        Name = g.Ad,
        MovieCount = g.Movies.Count
    };

    // GET /api/genres
    [HttpGet]
    public async Task<ActionResult<List<GenreDto>>> GetAll()
    {
        return await _context.Genres.OrderBy(g => g.Ad).Select(ToDto).ToListAsync();
    }

    // GET /api/genres/3
    [HttpGet("{id}")]
    public async Task<ActionResult<GenreDto>> GetById(int id)
    {
        var genre = await _context.Genres.Where(g => g.Id == id).Select(ToDto).FirstOrDefaultAsync();
        return genre is null ? NotFound() : genre;
    }

    // POST /api/genres
    // TODO: [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<ActionResult<GenreDto>> Create(GenreSaveDto dto)
    {
        var name = dto.Name.Trim();

        if (await _context.Genres.AnyAsync(g => g.Ad == name))
            return Conflict(new { error = $"'{name}' türü zaten var." });

        var genre = new Genre { Ad = name };
        _context.Genres.Add(genre);
        await _context.SaveChangesAsync();

        var created = await _context.Genres.Where(g => g.Id == genre.Id).Select(ToDto).FirstAsync();
        return CreatedAtAction(nameof(GetById), new { id = genre.Id }, created);
    }

    // PUT /api/genres/3
    // TODO: [Authorize(Roles = "Admin")]
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, GenreSaveDto dto)
    {
        var genre = await _context.Genres.FindAsync(id);
        if (genre is null) return NotFound();

        var name = dto.Name.Trim();

        if (await _context.Genres.AnyAsync(g => g.Ad == name && g.Id != id))
            return Conflict(new { error = $"'{name}' türü zaten var." });

        genre.Ad = name;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    // DELETE /api/genres/3
    // TODO: [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var genre = await _context.Genres.FindAsync(id);
        if (genre is null) return NotFound();

        if (await _context.Movies.AnyAsync(m => m.GenreId == id))
            return Conflict(new { error = "Bu türe ait filmler var. Önce filmleri silin ya da başka türe taşıyın." });

        _context.Genres.Remove(genre);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}