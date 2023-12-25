using System.Collections.Generic;
using DbWebApi.Models;
using Microsoft.Identity.Client;

namespace DbWebApi.Data 
{
    public interface IDoctorRepo 
    {
        bool SaveChange();

        // GET
        IEnumerable<Doctor> GetAllDoctors();

        // GET ID
        Doctor GetDoctorById(int id);

        // CREATE
        void NewDoctor(Doctor doc);

        // DELETE
        void DeleteDoctor(int id);

        // UPDATE
        void UpdateExperience(int id, int NewExperience);
    }
}