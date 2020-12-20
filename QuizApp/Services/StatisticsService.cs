using QuizApp.Backend.Library.Repositories.Interfaces;
using QuizApp.Backend.Library.Services.Interfaces;
using System.Threading.Tasks;
using static QuizApp.Backend.Library.Models.Enums.ResultTypeEnum;

namespace QuizApp.Backend.Library.Services
{
    public class StatisticsService : IStatisticsService
    {
        private readonly IResultRepository _resultRepository;

        public StatisticsService(IResultRepository resultRepository)
        {
            _resultRepository = resultRepository;
        }

        public async Task<int> GetAverageScoreAsync() => await _resultRepository.GetAverageScoreAsync();

        public async Task<int> GetNumberOfResultsAsync() => await _resultRepository.GetNumberOfResultsAsync();

        public async Task<int> GetNumberOfResultsByScoreAsync(short startScore, short endScore) => await _resultRepository.GetNumberOfResultsByScoreAsync(startScore, endScore);

        public async Task<int> GetNumberOfResultsByTypeAsync(ResultTypes resultType) => await _resultRepository.GetNumberOfResultsByTypeAsync(resultType);

        public async Task<int> GetNumberOfResultsByUserAsync(string userId) => await _resultRepository.GetNumberOfResultsByUserAsync(userId);
    }
}