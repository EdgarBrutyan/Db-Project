using System.Collections.Generic;
using DbWebApi.Models;
using System.Linq;

namespace DbWebApi.Data
{
    public class PatientRepo : IPatientRepo
    {
        private readonly AddDbContext _context;

        public PatientRepo(AddDbContext context)
        {
            _context = context;
        }

        public void NewPatient(Patient pat)
        {
            if(pat == null)
            {
                Console.WriteLine("The null value: NewPatient");
                throw new ArgumentNullException(nameof(pat));
            }

            _context.Patients.Add(pat); 
        }

        public bool SaveChange()
        {
            return (_context.SaveChanges() >= 0);
        }

        public IEnumerable<Patient> GetAllPatients()
        {
            return _context.Patients.ToList();
        }

        public Patient GetPatientById(int id)
        {
            return _context.Patients.FirstOrDefault(p => p.Id == id);
        }

        public void DeletePatient(int id)
        {
            var patinetToDelete = _context.Patients.Find(id);
            _context.Patients.Remove(patinetToDelete);
        }
    }
}