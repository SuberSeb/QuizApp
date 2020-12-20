using QuizApp.Backend.Library.Models;
using QuizApp.Backend.Library.Repositories.Interfaces;
using QuizApp.Backend.Library.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuizApp.Backend.Library.Services
{
    public class QuizService : IQuizService
    {
        private readonly IQuizRepository _quizRepository;

        public QuizService(IQuizRepository quizRepository)
        {
            _quizRepository = quizRepository;
        }

        public async Task AddQuizAsync(Quiz quiz) => await _quizRepository.AddQuizAsync(quiz);

        public async Task DeleteQuizAsync(Quiz quiz) => await _quizRepository.DeleteQuizAsync(quiz);

        public async Task<IEnumerable<Quiz>> GetAllQuizzesAsync() => await _quizRepository.GetAllQuizzesAsync();

        public async Task<Quiz> GetQuizByIdAsync(int quizId) => await _quizRepository.GetQuizByIdAsync(quizId);

        public async Task<IEnumerable<Quiz>> GetQuizzesByDateAsync(DateTime startDate, DateTime endDate) => await _quizRepository.GetQuizzesByDateAsync(startDate, endDate);

        public async Task ModifyQuizAsync(Quiz quiz) => await _quizRepository.ModifyQuizAsync(quiz);
    }
}