using System.ComponentModel.DataAnnotations;
using System;

namespace DbWebApi.Models
{
    public class Patient
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public DateTime Date_of_birth { get; set; }

        [Required]
        public string? Diagnosis { get; set; }
    }
}