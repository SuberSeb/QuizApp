using QuizApp.Backend.Library.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuizApp.Backend.Library.Repositories.Interfaces
{
    public interface IQuizRepository
    {
        Task<IEnumerable<Quiz>> GetAllQuizzesAsync();

        Task<Quiz> GetQuizByIdAsync(int quizId);

        Task AddQuizAsync(Quiz quiz);

        Task DeleteQuizAsync(Quiz quiz);

        Task ModifyQuizAsync(Quiz quiz);

        Task<IEnumerable<Quiz>> GetQuizzesByDateAsync(DateTime startDate, DateTime endDate);
    }
}