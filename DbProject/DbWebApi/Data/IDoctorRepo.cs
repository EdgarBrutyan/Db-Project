using System.Collections.Generic;
using DbWebApi.Models;

namespace DbWebApi.Data 
{
    public interface IDoctorRepo 
    {
        bool SaveChange();
        IEnumerable<Doctor> GetAllDoctors();

        Doctor GetDoctorById(int id);

        void NewDoctor(Doctor doc);

        void DeleteDoctor(int id);
    }
}