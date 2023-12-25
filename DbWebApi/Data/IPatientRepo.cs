using System.Collections.Generic;
using DbWebApi.Models;

namespace DbWebApi.Data 
{
    public interface IPatientRepo 
    {
        bool SaveChange();
        IEnumerable<Patient> GetAllPatients();

        Patient GetPatientById(int id);

        void NewPatient(Patient pat);

        void DeletePatient(int id);
    }
}