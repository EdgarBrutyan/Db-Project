using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using DbWebApi.Data;
using DbWebApi.Models;

namespace DbWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TreatmentsController : ControllerBase
    {
        private readonly ITreatmentRepo _repository;

        public TreatmentsController(ITreatmentRepo repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Treatment>> GetAllTreatments()
        {
            try
            {
                var treatments = _repository.GetAllTreatments().ToList();
                return Ok(treatments);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{diagnosis}")]
        public ActionResult<Treatment> GetTreatmentByDiagnosis(string diagnosis)
        {
            var treatment = _repository.GetTreatmentByDiagnosis(diagnosis);

            if (treatment != null)
            {
                return Ok(treatment);
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult<Treatment> CreateTreatment(Treatment treatment)
        {
            try
            {
                _repository.CreateTreatment(treatment);
                _repository.SaveChange();

                return CreatedAtAction(nameof(GetTreatmentByDiagnosis), new { diagnosis = treatment.Diagnosis }, treatment);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{diagnosis}")]
        public ActionResult DeleteTreatment(string diagnosis)
        {
            var existingTreatment = _repository.GetTreatmentByDiagnosis(diagnosis);

            if (existingTreatment == null)
            {
                return NotFound();
            }

            try
            {
                _repository.DeleteTreatment(existingTreatment);
                _repository.SaveChange();

                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{diagnosis}")]
        public ActionResult<Treatment> UpdateTreatment(string diagnosis, Treatment updatedTreatment)
        {
            var existingTreatment = _repository.GetTreatmentByDiagnosis(diagnosis);

            if (existingTreatment == null)
            {
                return NotFound();
            }

            try
            {
                // Update the properties of the existing treatment with the values from updatedTreatment
                existingTreatment.Date_of_starting = updatedTreatment.Date_of_starting;
                existingTreatment.Date_of_finishing = updatedTreatment.Date_of_finishing;
                existingTreatment.DoctorId = updatedTreatment.DoctorId;
                existingTreatment.CurrentState = updatedTreatment.CurrentState;

                _repository.SaveChange();

                return Ok(existingTreatment);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        // Add other CRUD actions (UpdateTreatment, DeleteTreatment) as needed
    }
}
