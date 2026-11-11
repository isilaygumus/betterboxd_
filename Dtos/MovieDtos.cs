using System.ComponentModel.DataAnnotations;

namespace betterboxd_web.Dtos;

// API'den dönen film (mobilin okuduğu JSON alanlarıyla aynı)
public class MovieDto
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Director { get; set; } = null!;
    public int Year { get; set; }
    public decimal Rating { get; set; }
    public string? PosterUrl { get; set; }
    public string Genre { get; set; } = null!;
}

// POST ve PUT isteklerinde gönderilen alanlar
public class MovieSaveDto
{
    [Required, StringLength(150)]
    public string Title { get; set; } = null!;

    [Required, StringLength(100)]
    public string Director { get; set; } = null!;

    [Range(1888, 2100)]
    public int Year { get; set; }

    [Range(0.0, 5.0)]
    public decimal Rating { get; set; }

    [StringLength(300)]
    public string? PosterUrl { get; set; }

    [Range(1, int.MaxValue)]
    public int GenreId { get; set; }
}