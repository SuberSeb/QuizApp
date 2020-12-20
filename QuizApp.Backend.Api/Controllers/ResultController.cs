using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QuizApp.Backend.Library.Models;
using QuizApp.Backend.Library.Models.Identity;
using QuizApp.Backend.Library.Services.Interfaces;
using System;
using System.Threading.Tasks;
using static QuizApp.Backend.Library.Models.Enums.ResultTypeEnum;

namespace QuizApp.Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultController : Controller
    {
        private readonly IResultService _resultService;
        private readonly ILogger<QuizController> _logger;

        public ResultController(IResultService resultService, ILogger<QuizController> logger)
        {
            _resultService = resultService ?? throw new ArgumentNullException(nameof(resultService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [Authorize(Roles = UserRoles.ADMIN)]
        [HttpGet]
        public async Task<JsonResult> GetResultsAsync()
        {
            try
            {
                var results = await _resultService.GetResultsAsync();
                return Json(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in {nameof(GetResultsAsync)}; Exception: {ex.Message}, stack trace: {ex.StackTrace}");
                return Json(ex.Message);
            }
        }

        [Authorize(Roles = UserRoles.ADMIN)]
        [HttpGet("type")]
        public async Task<JsonResult> GetResultsByTypeAsync(ResultTypes resultType)
        {
            try
            {
                var results = await _resultService.GetResultsByTypeAsync(resultType);
                return Json(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in {nameof(GetResultsByTypeAsync)}; Exception: {ex.Message}, stack trace: {ex.StackTrace}");
                return Json(ex.Message);
            }
        }

        [Authorize(Roles = UserRoles.ADMIN)]
        [HttpGet("user")]
        public async Task<JsonResult> GetResultsByUserAsync(string userId)
        {
            try
            {
                var results = await _resultService.GetResultsByUserAsync(userId);
                return Json(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in {nameof(GetResultsByUserAsync)}; Exception: {ex.Message}, stack trace: {ex.StackTrace}");
                return Json(ex.Message);
            }
        }

        [Authorize(Roles = UserRoles.ADMIN)]
        [HttpGet("score")]
        public async Task<JsonResult> GetResultsByScoreAsync(short startScore, short endScore)
        {
            try
            {
                var results = await _resultService.GetResultsByScoreAsync(startScore, endScore);
                return Json(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in {nameof(GetResultsByUserAsync)}; Exception: {ex.Message}, stack trace: {ex.StackTrace}");
                return Json(ex.Message);
            }
        }

        [Authorize(Roles = UserRoles.ADMIN)]
        [HttpGet("average")]
        public async Task<JsonResult> GetAverageScoreAsync()
        {
            try
            {
                var results = await _resultService.GetAverageScoreAsync();
                return Json(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in {nameof(GetAverageScoreAsync)}; Exception: {ex.Message}, stack trace: {ex.StackTrace}");
                return Json(ex.Message);
            }
        }

        [Authorize]
        [HttpPost("set")]
        public async Task<JsonResult> SetResultAsync(Quiz quiz)
        {
            try
            {
                var result = await _resultService.SetResultAsync(quiz);
                return Json(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in {nameof(SetResultAsync)}; Exception: {ex.Message}, stack trace: {ex.StackTrace}");
                return Json(ex.Message);
            }
        }
    }
}