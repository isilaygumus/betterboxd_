namespace betterboxd_web.Models;

public class ListMovie
{
    public int MovieListId { get; set; }
    public MovieList MovieList { get; set; } = null!;

    public int MovieId { get; set; }
    public Movie Movie { get; set; } = null!;

    public DateTime AddedAt { get; set; } = DateTime.UtcNow;
}