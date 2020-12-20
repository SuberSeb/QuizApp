using QuizApp.Backend.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using static QuizApp.Backend.Library.Models.Enums.ResultTypeEnum;

namespace QuizApp.Backend.Library.Services.Interfaces
{
    public interface IResultService
    {
        Task<Result> SetResultAsync(Quiz quiz);

        Task<IEnumerable<Result>> GetResultsByTypeAsync(ResultTypes resultType);

        Task<IEnumerable<Result>> GetResultsAsync();

        Task<IEnumerable<Result>> GetResultsByUserAsync(string userId);

        Task<IEnumerable<Result>> GetResultsByScoreAsync(short startScore, short endScore);

        Task<int> GetAverageScoreAsync();
    }
}