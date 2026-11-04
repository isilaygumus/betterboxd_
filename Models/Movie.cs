using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace betterboxd_web.Models
{
    public class Movie

    {
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Director { get; set; } = string.Empty;

        public int Year { get; set; }

        // 0 ile 5 arası puan (ör. 4.5)
        [Range(0, 5)]
        [Column(TypeName = "decimal(2,1)")]
        public decimal Rating { get; set; }

        public DateTime AddedDate { get; set; }

        // Afiş resminin internet adresi (TMDB). Boş olabilir.
        [StringLength(300)]
        public string? PosterUrl { get; set; }

        // Yabancı anahtar (foreign key)
        public int GenreId { get; set; }

        // Navigation property: filmin türü
        public Genre? Genre { get; set; }
    }
}
