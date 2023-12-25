using System.Collections.Generic;
using DbWebApi.Models;
using System.Linq;

namespace DbWebApi.Data
{
    public class DoctorRepo : IDoctorRepo
    {
        private readonly AddDbContext _context;

        public DoctorRepo(AddDbContext context)
        {
            _context = context;
        }

        public void NewDoctor(Doctor doc)
        {
            if(doc == null)
            {
                Console.WriteLine("The null value: NewDoctor");
                throw new ArgumentNullException(nameof(doc));
            }

            _context.Doctors.Add(doc); 
        }

        public bool SaveChange()
        {
            return (_context.SaveChanges() >= 0);
        }

        public IEnumerable<Doctor> GetAllDoctors()
        {
            return _context.Doctors.AsQueryable().ToList();
        }

        public Doctor GetDoctorById(int id)
        {
            return _context.Doctors.FirstOrDefault(p => p.Id == id);
        }
 
        public void DeleteDoctor(int id)
        {
            var doctorToDelete = _context.Doctors.Find(id);
            _context.Doctors.Remove(doctorToDelete);
        }

        public void UpdateExperience(int id, int NewExperience)
        {
            var doctorToUpdate = _context.Doctors.Find(id);
            doctorToUpdate.Experience = NewExperience;
            _context.Doctors.Update(doctorToUpdate);
        }

    }
}