using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using QuizApp.Backend.Library.Database;
using QuizApp.Backend.Library.Models;
using QuizApp.Backend.Library.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static QuizApp.Backend.Library.Models.Enums.ResultTypeEnum;

namespace QuizApp.Backend.Library.Repositories
{
    public class ResultRepository : IResultRepository
    {
        private readonly ILogger<ResultRepository> _logger;
        private readonly DataContext _dataContext;

        public ResultRepository(DataContext dataContext, ILogger<ResultRepository> logger)
        {
            _dataContext = dataContext;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<int> GetAverageScoreAsync()
        {
            try
            {
                var results = await _dataContext.Results.ToListAsync();
                var scoreSum = 0;

                foreach (var result in results)
                {
                    scoreSum += result.TotalScore;
                }

                return scoreSum / results.Count;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in {nameof(GetAverageScoreAsync)}; Exception: {ex.Message}, stack trace: {ex.StackTrace}");
                return default;
            }
        }

        public async Task<int> GetNumberOfResultsAsync()
        {
            try
            {
                var results = await _dataContext.Results.ToListAsync();
                return results.Count;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in {nameof(GetNumberOfResultsAsync)}; Exception: {ex.Message}, stack trace: {ex.StackTrace}");
                return default;
            }
        }

        public async Task<int> GetNumberOfResultsByScoreAsync(short startScore, short endScore)
        {
            try
            {
                var results = await _dataContext.Results.Where(r => r.TotalScore > startScore && r.TotalScore < endScore).ToListAsync();
                return results.Count;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in {nameof(GetNumberOfResultsByScoreAsync)}; Exception: {ex.Message}, stack trace: {ex.StackTrace}");
                return default;
            }
        }

        public async Task<int> GetNumberOfResultsByTypeAsync(ResultTypes resultType)
        {
            try
            {
                var results = await _dataContext.Results.Where(r => r.ResultType == resultType).ToListAsync();
                return results.Count;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in {nameof(GetNumberOfResultsByTypeAsync)}; Exception: {ex.Message}, stack trace: {ex.StackTrace}");
                return default;
            }
        }

        public async Task<int> GetNumberOfResultsByUserAsync(string userId)
        {
            try
            {
                var results = await _dataContext.Results.Where(r => r.UserId == userId).ToListAsync();
                return results.Count;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in {nameof(GetResultsAsync)}; Exception: {ex.Message}, stack trace: {ex.StackTrace}");
                return default;
            }
        }

        public async Task<IEnumerable<Result>> GetResultsAsync()
        {
            try
            {
                return await _dataContext.Results.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in {nameof(GetResultsAsync)}; Exception: {ex.Message}, stack trace: {ex.StackTrace}");
                return default;
            }
        }

        public async Task<IEnumerable<Result>> GetResultsByScoreAsync(short startScore, short endScore)
        {
            try
            {
                return await _dataContext.Results.Where(r => r.TotalScore > startScore && r.TotalScore < endScore).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in {nameof(GetResultsByScoreAsync)}; Exception: {ex.Message}, stack trace: {ex.StackTrace}");
                return default;
            }
        }

        public async Task<IEnumerable<Result>> GetResultsByTypeAsync(ResultTypes resultType)
        {
            try
            {
                return await _dataContext.Results.Where(r => r.ResultType == resultType).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in {nameof(GetResultsByTypeAsync)}; Exception: {ex.Message}, stack trace: {ex.StackTrace}");
                return default;
            }
        }

        public async Task<IEnumerable<Result>> GetResultsByUserAsync(string userId)
        {
            try
            {
                return await _dataContext.Results.Where(r => r.UserId == userId).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in {nameof(GetResultsByUserAsync)}; Exception: {ex.Message}, stack trace: {ex.StackTrace}");
                return default;
            }
        }

        public async Task<Result> SetResultAsync(Quiz quiz, ResultTypes resultType, short score)
        {
            try
            {
                var result = new Result()
                {
                    TotalScore = score,
                    ResultType = resultType,
                    Date = DateTime.Now,
                    QuizId = quiz.QuizId,
                    Description = resultType.ToString(),
                    UserId = "simpleuserid" //TODO: Result User
                };

                _dataContext.Results.Add(result);
                await _dataContext.SaveChangesAsync();
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in {nameof(SetResultAsync)}; Exception: {ex.Message}, stack trace: {ex.StackTrace}");
                return new Result();
            }
        }
    }
}