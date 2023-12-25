using System.Collections.Generic;
using DbWebApi.Models;

namespace DbWebApi.Data 
{
    public interface ITreatmentRepo
    {
        public bool SaveChange();
        public IEnumerable<Treatment> GetAllTreatments();
        public void CreateTreatment(Treatment treatment);
        public void DeleteTreatment(Treatment treatment);
        public Treatment GetTreatmentByDiagnosis(string diagnosis);
    }
}