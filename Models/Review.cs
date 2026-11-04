using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace betterboxd_web.Models;

public class Review
{
    public int Id { get; set; }

    public int MovieId { get; set; }
    public Movie Movie { get; set; } = null!;

    public string UserId { get; set; } = null!;
    public IdentityUser User { get; set; } = null!;

    [Range(0.5, 5)]
    public decimal Rating { get; set; }

    [StringLength(1000)]
    public string? Comment { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}