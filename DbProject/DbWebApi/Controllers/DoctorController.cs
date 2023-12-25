using Microsoft.AspNetCore.Mvc;
using DbWebApi.Data;
using DbWebApi.Models;

namespace DbWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorRepo _doctorRepo;

        public DoctorController(IDoctorRepo doctorRepo)
        {
            _doctorRepo = doctorRepo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Doctor>> GetAllDoctors()
        {
            var doctors = _doctorRepo.GetAllDoctors();
            return Ok(doctors);
        }

        [HttpGet("{id}")]
        public IActionResult GetDoctorById(int id)
        {
            var doctor = _doctorRepo.GetDoctorById(id);

            if (doctor == null)
            {
                return NotFound(); // Возвращаем 404 Not Found, если доктор не найден
            }

            return Ok(doctor);
        }

        [HttpPost]
        public IActionResult NewDoctor([FromBody] Doctor doctor)
        {
            if (doctor == null)
            {
                return BadRequest(); // Возвращаем 400 Bad Request, если данные доктора некорректны
            }

            _doctorRepo.NewDoctor(doctor);
            _doctorRepo.SaveChange();

            return CreatedAtAction(nameof(GetDoctorById), new { id = doctor.Id }, doctor);
        }


        [HttpPut("{id}")]
        public IActionResult UpdateExperience(int id, int NewExpericen)
        {
            if (NewExpericen == 0)
            {
                return BadRequest();
            }

            if (_doctorRepo.GetDoctorById(id) == null)
            {
                return NotFound();
            }

            _doctorRepo.UpdateExperience(id, NewExpericen);
            _doctorRepo.SaveChange();

            return Ok("The Doctor was Successfully updated");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDoctor(int id)
        {
            var doctor = _doctorRepo.GetDoctorById(id);

            if (doctor == null)
            {
                return NotFound();
            }

            _doctorRepo.DeleteDoctor(id);
            _doctorRepo.SaveChange();

            return Ok("The Docktor was successfully removed");
        }
    }
}
