using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace betterboxd_web.Models
{
    public class Film
    {
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Ad { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Yonetmen { get; set; } = string.Empty;

        public int Yil { get; set; }

        // 0 ile 5 arası puan (ör. 4.5)
        [Range(0, 5)]
        [Column(TypeName = "decimal(2,1)")]
        public decimal Puan { get; set; }

        public DateTime EklenmeTarihi { get; set; }

        // Afiş resminin internet adresi (TMDB). Boş olabilir.
        [StringLength(300)]
        public string? AfisUrl { get; set; }

        // Yabancı anahtar (foreign key)
        public int TurId { get; set; }

        // Navigation property: filmin türü
        public Tur? Tur { get; set; }
    }
}
