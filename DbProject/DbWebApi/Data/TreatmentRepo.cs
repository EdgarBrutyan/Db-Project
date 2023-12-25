using System.Collections.Generic;
using DbWebApi.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DbWebApi.Data
{
    public class TreatmentRepo : ITreatmentRepo
    {
        private readonly AddDbContext _context;

        public TreatmentRepo(AddDbContext context)
        {
            _context = context;
        }
        public bool SaveChange()
        {
            return (_context.SaveChanges() >= 0);
        }

        public IEnumerable<Treatment> GetAllTreatments()
        {
            return _context.Treatments.ToList();
        }

        public void CreateTreatment(Treatment treatment)
        {
            if (treatment == null)
            {
                throw new ArgumentNullException(nameof(treatment));
            }

            _context.Treatments.Add(treatment);
        }


        public void UpdateTreatment(string diagnosis, Treatment updatedTreatment)
        {
            var existingTreatment = _context.Treatments.SingleOrDefault(t => t.Diagnosis == diagnosis);

            if (existingTreatment == null)
            {
                throw new KeyNotFoundException($"Treatment with diagnosis {diagnosis} not found");
            }

            existingTreatment.Date_of_starting = updatedTreatment.Date_of_starting;
            existingTreatment.Date_of_finishing = updatedTreatment.Date_of_finishing;
            existingTreatment.DoctorId = updatedTreatment.DoctorId;
            existingTreatment.CurrentState = updatedTreatment.CurrentState;
        }

        public void DeleteTreatment(Treatment treatment)
        {
            if (treatment == null)
            {
                throw new ArgumentNullException(nameof(treatment));
            }

            _context.Treatments.Remove(treatment);
        }

        public Treatment GetTreatmentByDiagnosis(string diagnosis)
        {
            return _context.Treatments.SingleOrDefault(t => t.Diagnosis == diagnosis);
        }

    }
}