using System.Collections.Generic;
using System.Linq;
using DbWebApi.Models;

namespace DbWebApi.Data
{
    public class CustomQueryRepo : ICustomQueryRepo
    {
        private readonly AddDbContext _context;

        public CustomQueryRepo(AddDbContext context)
        {
            _context = context;
        }

        public IEnumerable<object> GetResultsWithFilterAndJoin(string currentState, int doctorId)
        {
            // Ваша логика для запроса с WHERE и JOIN
            return _context.Treatments
                .Where(t => t.CurrentState == currentState && t.DoctorId == doctorId)
                .Select(t => new
                {
                    // Ваши поля
                    Diagnosis = t.Diagnosis,
                    Date_of_starting = t.Date_of_starting,
                    // Дополнительные поля, если необходимо
                })
                .ToList();
        }

        public void UpdateResultsWithComplexCondition(string currentStateToUpdate, string newState)
        {
            // Ваша логика для UPDATE с нетривиальным условием
            var treatmentsToUpdate = _context.Treatments
                .Where(t => t.CurrentState == currentStateToUpdate)
                .ToList();

            foreach (var treatment in treatmentsToUpdate)
            {
                treatment.CurrentState = newState;
            }
        }

        public IEnumerable<object> GetResultsCountByState()
        {
            // Ваша логика для GROUP BY
            return _context.Treatments
                .GroupBy(t => t.CurrentState)
                .Select(group => new
                {
                    State = group.Key,
                    Count = group.Count()
                })
                .ToList();
        }

        public IEnumerable<object> GetSortedResults(string sortBy)
        {
            // Ваша логика для сортировки
            return _context.Treatments
                .OrderBy(t => sortBy)
                .Select(t => new
                {
                    // Ваши поля
                    Diagnosis = t.Diagnosis,
                    Date_of_starting = t.Date_of_starting,
                    // Дополнительные поля, если необходимо
                })
                .ToList();
        }

        public bool SaveChange()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
