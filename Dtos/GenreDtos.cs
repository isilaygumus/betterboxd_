using System.ComponentModel.DataAnnotations;

namespace betterboxd_web.Dtos;

public class GenreDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int MovieCount { get; set; }
}

public class GenreSaveDto
{
    [Required, StringLength(50)]
    public string Name { get; set; } = null!;
}