using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace betterboxd_web.Models;

public class MovieList
{
    public int Id { get; set; }

    [Required, StringLength(100)]
    public string Name { get; set; } = null!;

    [StringLength(500)]
    public string? Description { get; set; }

    public string UserId { get; set; } = null!;
    public IdentityUser User { get; set; } = null!;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public ICollection<ListMovie> ListMovies { get; set; } = new List<ListMovie>();
}
