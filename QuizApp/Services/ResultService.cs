using QuizApp.Backend.Library.Models;
using QuizApp.Backend.Library.Repositories.Interfaces;
using QuizApp.Backend.Library.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static QuizApp.Backend.Library.Models.Enums.ResultTypeEnum;

namespace QuizApp.Backend.Library.Services
{
    public class ResultService : IResultService
    {
        private readonly IResultRepository _resultRepository;
        private readonly ICalculationService _calculationService;

        public ResultService(IResultRepository resultRepository, ICalculationService calculationService)
        {
            _resultRepository = resultRepository;
            _calculationService = calculationService ?? throw new ArgumentNullException(nameof(calculationService));
        }

        public async Task<int> GetAverageScoreAsync() => await _resultRepository.GetAverageScoreAsync();

        public async Task<IEnumerable<Result>> GetResultsAsync() => await _resultRepository.GetResultsAsync();

        public async Task<IEnumerable<Result>> GetResultsByScoreAsync(short startScore, short endScore) => await _resultRepository.GetResultsByScoreAsync(startScore, endScore);

        public async Task<IEnumerable<Result>> GetResultsByTypeAsync(ResultTypes resultType) => await _resultRepository.GetResultsByTypeAsync(resultType);

        public async Task<IEnumerable<Result>> GetResultsByUserAsync(string userId) => await _resultRepository.GetResultsByUserAsync(userId);

        public async Task<Result> SetResultAsync(Quiz quiz)
        {
            var score = _calculationService.CalcQuizScore(quiz);
            var resultType = _calculationService.GetQuizResultType(score);
            return await _resultRepository.SetResultAsync(quiz, resultType, score);
        }
    }
}