using Microsoft.AspNetCore.Mvc;
using DbWebApi.Data;
using DbWebApi.Models;
using DbWebApi.Data;
using DbWebApi.Models;

namespace DbWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientRepo _patientRepo;

        public PatientController(IPatientRepo patientRepo)
        {
            _patientRepo = patientRepo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Patient>> GetAllPatients()
        {
            var doctors = _patientRepo.GetAllPatients();
            return Ok(doctors);
        }

        [HttpGet("{id}")]
        public IActionResult GetPatientById(int id)
        {
            var patient = _patientRepo.GetPatientById(id);

            if (patient == null)
            {
                return NotFound(); // Возвращаем 404 Not Found, если доктор не найден
            }

            return Ok(patient);
        }

        [HttpPost]
        public IActionResult NewPatient([FromBody] Patient patient)
        {
            if (patient == null)
            {
                return BadRequest(); // Возвращаем 400 Bad Request, если данные доктора некорректны
            }

            _patientRepo.NewPatient(patient);
            _patientRepo.SaveChange();

            return CreatedAtAction(nameof(GetPatientById), new { id = patient.Id }, patient);
        }


        [HttpDelete("{id}")]
        public IActionResult DeletePatient(int id)
        {
            var patient = _patientRepo.GetPatientById(id);

            if (patient == null)
            {
                return NotFound();
            }

            _patientRepo.DeletePatient(id);
            _patientRepo.SaveChange();

            return Ok("The Docktor was successfully removed");
        }
    }
}

    

