using QuizApp.Backend.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using static QuizApp.Backend.Library.Models.Enums.ResultTypeEnum;

namespace QuizApp.Backend.Library.Repositories.Interfaces
{
    public interface IResultRepository
    {
        Task<Result> SetResultAsync(Quiz quiz, ResultTypes resultType, short score);

        Task<IEnumerable<Result>> GetResultsByTypeAsync(ResultTypes resultType);

        Task<IEnumerable<Result>> GetResultsAsync();

        Task<IEnumerable<Result>> GetResultsByUserAsync(string userId);

        Task<IEnumerable<Result>> GetResultsByScoreAsync(short startScore, short endScore);

        Task<int> GetAverageScoreAsync();

        Task<int> GetNumberOfResultsByTypeAsync(ResultTypes resultType);

        Task<int> GetNumberOfResultsAsync();

        Task<int> GetNumberOfResultsByUserAsync(string userId);

        Task<int> GetNumberOfResultsByScoreAsync(short startScore, short endScore);
    }
}