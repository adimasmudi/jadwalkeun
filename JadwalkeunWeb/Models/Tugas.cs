using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace JadwalkeunWeb.Models
{
    public class Tugas
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [DisplayName("Display Amount")]
        [Range(1000, 1000000, ErrorMessage = "Amount is just between 1000 until 1000000 rupiah")]
        public int DisplayAmount { get; set; }
        [Required]
        public string? Status { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
