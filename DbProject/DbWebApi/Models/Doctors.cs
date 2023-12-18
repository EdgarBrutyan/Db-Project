using System.ComponentModel.DataAnnotations;

namespace DbWebApi.Models
{
    public class Doctor
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Surname { get; set; }

        [Required]
        public string? Specialization { get; set; } 

        [Required]
        public int Experience { get; set; }
    }
}