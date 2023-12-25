using Microsoft.AspNetCore.Mvc;
using DbWebApi.Data;
using DbWebApi.Models;
using System.Collections.Generic;

namespace DbWebApi.Controllers
{
    [ApiController]
    [Route("api/custom")]
    public class CustomQueriesController : ControllerBase
    {
        private readonly ICustomQueryRepo _customQueryRepo;

        public CustomQueriesController(ICustomQueryRepo customQueryRepo)
        {
            _customQueryRepo = customQueryRepo;
        }

        // SELECT ... WHERE (с несколькими условиями) и JOIN
        [HttpGet("filter-and-join")]
        public IActionResult GetResultsWithFilterAndJoin(string currentState, int doctorId)
        {
            var results = _customQueryRepo.GetResultsWithFilterAndJoin(currentState, doctorId);
            return Ok(results);
        }

        // UPDATE с нетривиальным условием
        [HttpPut("update")]
        public IActionResult UpdateResultsWithComplexCondition(string currentStateToUpdate, string newState)
        {
            _customQueryRepo.UpdateResultsWithComplexCondition(currentStateToUpdate, newState);
            _customQueryRepo.SaveChange();
            return NoContent();
        }

        // GROUP BY
        [HttpGet("groupby")]
        public IActionResult GetResultsCountByState()
        {
            var resultsCountByState = _customQueryRepo.GetResultsCountByState();
            return Ok(resultsCountByState);
        }

        // Добавить к параметрам запросов в API сортировку выдачи результатов по какому-то из полей
        [HttpGet("sorted")]
        public IActionResult GetSortedResults(string sortBy)
        {
            var sortedResults = _customQueryRepo.GetSortedResults(sortBy);
            return Ok(sortedResults);
        }
    }
}
