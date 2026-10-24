using System.ComponentModel.DataAnnotations;

namespace betterboxd_web.Models
{
    public class Tur
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Ad { get; set; } = string.Empty;

        // Bire-çok ilişki: bir türün birden çok filmi olabilir
        public List<Film> Filmler { get; set; } = new();
    }
}
