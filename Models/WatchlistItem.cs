using Microsoft.AspNetCore.Identity;

namespace betterboxd_web.Models;

public class WatchlistItem
{
    public int Id { get; set; }

    public string UserId { get; set; } = null!;
    public IdentityUser User { get; set; } = null!;

    public int MovieId { get; set; }
    public Movie Movie { get; set; } = null!;

    public DateTime AddedAt { get; set; } = DateTime.UtcNow;
}