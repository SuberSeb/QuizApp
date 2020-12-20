using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QuizApp.Backend.Library.Models;
using QuizApp.Backend.Library.Models.Identity;
using QuizApp.Backend.Library.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace QuizApp.Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : Controller
    {
        private readonly IQuizService _quizService;
        private readonly ILogger<QuizController> _logger;

        public QuizController(IQuizService quizService, ILogger<QuizController> logger)
        {
            _quizService = quizService ?? throw new ArgumentNullException(nameof(quizService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public async Task<JsonResult> GetQuizzesAsync()
        {
            try
            {
                var quizzes = await _quizService.GetAllQuizzesAsync();
                return Json(quizzes);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in {nameof(GetQuizzesAsync)}; Exception: {ex.Message}, stack trace: {ex.StackTrace}");
                return Json(ex.Message);
            }
        }

        [HttpGet("id")]
        public async Task<JsonResult> GetQuizAsync(int quizId)
        {
            try
            {
                var quiz = await _quizService.GetQuizByIdAsync(quizId);
                return Json(quiz);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in {nameof(GetQuizAsync)}; Exception: {ex.Message}, stack trace: {ex.StackTrace}");
                return Json(ex.Message);
            }
        }

        [HttpGet("date")]
        public async Task<JsonResult> GetQuizzesByDateAsync(DateTime startDate, DateTime endDate)
        {
            try
            {
                var quizzes = await _quizService.GetQuizzesByDateAsync(startDate, endDate);
                return Json(quizzes);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in {nameof(GetQuizzesAsync)}; Exception: {ex.Message}, stack trace: {ex.StackTrace}");
                return Json(ex.Message);
            }
        }

        [Authorize(Roles = UserRoles.ADMIN)]
        [HttpPost("add")]
        public async Task AddQuizAsync(Quiz quiz)
        {
            try
            {
                await _quizService.AddQuizAsync(quiz);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in {nameof(AddQuizAsync)}; Exception: {ex.Message}, stack trace: {ex.StackTrace}");
            }
        }

        [Authorize(Roles = UserRoles.ADMIN)]
        [HttpPost("delete")]
        public async Task DeleteQuizAsync(Quiz quiz)
        {
            try
            {
                await _quizService.DeleteQuizAsync(quiz);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in {nameof(DeleteQuizAsync)}; Exception: {ex.Message}, stack trace: {ex.StackTrace}");
            }
        }

        [Authorize(Roles = UserRoles.ADMIN)]
        [HttpPost("modify")]
        public async Task ModifyQuizAsync(Quiz quiz)
        {
            try
            {
                await _quizService.ModifyQuizAsync(quiz);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in {nameof(ModifyQuizAsync)}; Exception: {ex.Message}, stack trace: {ex.StackTrace}");
            }
        }
    }
}