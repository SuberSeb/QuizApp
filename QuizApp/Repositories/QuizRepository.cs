using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using QuizApp.Backend.Library.Database;
using QuizApp.Backend.Library.Models;
using QuizApp.Backend.Library.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.Backend.Library.Repositories
{
    public class QuizRepository : IQuizRepository
    {
        private readonly ILogger<QuizRepository> _logger;
        private readonly DataContext _dataContext;

        public QuizRepository(DataContext dataContext, ILogger<QuizRepository> logger)
        {
            _dataContext = dataContext;
            _logger = logger;
        }

        public async Task<IEnumerable<Quiz>> GetAllQuizzesAsync()
        {
            try
            {
                return await _dataContext.Quizzes
                    .Include(q => q.Questions).ThenInclude(q => q.Answers)
                    .Include(r => r.Results).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in {nameof(GetAllQuizzesAsync)}; Exception: {ex.Message}, stack trace: {ex.StackTrace}");
                return new List<Quiz>();
            }
        }

        public async Task<Quiz> GetQuizByIdAsync(int quizId)
        {
            try
            {
                return await _dataContext.Quizzes
                    .Include(q => q.Questions).ThenInclude(q => q.Answers)
                    .Include(r => r.Results).FirstOrDefaultAsync(q => q.QuizId == quizId);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in {nameof(GetQuizByIdAsync)}; Exception: {ex.Message}, stack trace: {ex.StackTrace}");
                return new Quiz();
            }
        }

        public async Task AddQuizAsync(Quiz quiz)
        {
            try
            {
                _dataContext.Quizzes.Add(quiz);
                await _dataContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in {nameof(AddQuizAsync)}; Exception: {ex.Message}, stack trace: {ex.StackTrace}");
            }
        }

        public async Task DeleteQuizAsync(Quiz quiz)
        {
            try
            {
                _dataContext.Quizzes.Remove(quiz);
                await _dataContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in {nameof(DeleteQuizAsync)}; Exception: {ex.Message}, stack trace: {ex.StackTrace}");
            }
        }

        public async Task ModifyQuizAsync(Quiz quiz)
        {
            try
            {
                Quiz quizFromDb = await _dataContext.Quizzes.SingleOrDefaultAsync(q => q.QuizId == quiz.QuizId);

                if (quizFromDb != null)
                {
                    quizFromDb.Title = quiz.Title;
                    quizFromDb.Description = quiz.Description;
                    quizFromDb.CreatedDate = quiz.CreatedDate;
                    quizFromDb.Questions = quiz.Questions;
                    quizFromDb.Results = quiz.Results;
                }

                await _dataContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in {nameof(ModifyQuizAsync)}; Exception: {ex.Message}, stack trace: {ex.StackTrace}");
            }
        }

        public async Task<IEnumerable<Quiz>> GetQuizzesByDateAsync(DateTime startDate, DateTime endDate)
        {
            try
            {
                return await _dataContext.Quizzes
                    .Include(q => q.Questions).ThenInclude(q => q.Answers)
                    .Include(r => r.Results)
                    .Where(q => q.CreatedDate > startDate && q.CreatedDate < endDate)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in {nameof(GetQuizzesByDateAsync)}; Exception: {ex.Message}, stack trace: {ex.StackTrace}");
                return new List<Quiz>();
            }
        }
    }
}