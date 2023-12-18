using Microsoft.EntityFrameworkCore;
using DbWebApi.Models;

namespace DbWebApi.Data
{
    public class AddDbContext : DbContext 
    {
        public AddDbContext(DbContextOptions<AddDbContext> option) : base(option)
        {

        }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; } 
    }
}