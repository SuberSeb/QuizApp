using System.Threading.Tasks;
using static QuizApp.Backend.Library.Models.Enums.ResultTypeEnum;

namespace QuizApp.Backend.Library.Services.Interfaces
{
    public interface IStatisticsService
    {
        Task<int> GetNumberOfResultsByTypeAsync(ResultTypes resultType);

        Task<int> GetNumberOfResultsAsync();

        Task<int> GetNumberOfResultsByUserAsync(string userId);

        Task<int> GetNumberOfResultsByScoreAsync(short startScore, short endScore);

        Task<int> GetAverageScoreAsync();
    }
}