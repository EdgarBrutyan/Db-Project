using System.ComponentModel.DataAnnotations;

namespace DbWebApi.Models
{
    public class Patient
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public int DoctorId { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Surname { get; set; }

        [Required]
        public string? Disease { get; set; }
    }
}