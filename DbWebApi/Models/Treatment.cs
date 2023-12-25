using System.ComponentModel.DataAnnotations;
using System;

namespace DbWebApi.Models
{
    public class Treatment
    {

        [Key]
        [Required]
        public string Diagnosis { get; set; }

        [Required]
        public DateTime Date_of_starting { get; set; }

        [Required]
        public DateTime Date_of_finishing { get; set; }

        [Required]
        public int DoctorId { get; set; }

        [Required]
        public string CurrentState { get; set; }

    }
}