using System.Collections.Generic;

namespace DbWebApi.Data
{
    public interface ICustomQueryRepo
    {
        IEnumerable<object> GetResultsWithFilterAndJoin(string currentState, int doctorId);

        void UpdateResultsWithComplexCondition(string currentStateToUpdate, string newState);

        IEnumerable<object> GetResultsCountByState();

        IEnumerable<object> GetSortedResults(string sortBy);

        bool SaveChange();
    }
}
