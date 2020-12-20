using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QuizApp.Backend.Library.Models.Identity;
using QuizApp.Backend.Library.Services.Interfaces;
using System;
using System.Threading.Tasks;
using static QuizApp.Backend.Library.Models.Enums.ResultTypeEnum;

namespace QuizApp.Backend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : Controller
    {
        private readonly IStatisticsService _statisticsService;
        private readonly ILogger<QuizController> _logger;

        public StatisticsController(IStatisticsService statisticsService, ILogger<QuizController> logger)
        {
            _statisticsService = statisticsService ?? throw new ArgumentNullException(nameof(statisticsService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [Authorize(Roles = UserRoles.ADMIN)]
        [HttpGet]
        public async Task<JsonResult> GetNumberOfResultsAsync()
        {
            try
            {
                var number = await _statisticsService.GetNumberOfResultsAsync();
                return Json(number);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in {nameof(GetNumberOfResultsAsync)}; Exception: {ex.Message}, stack trace: {ex.StackTrace}");
                return Json(ex.Message);
            }
        }

        [Authorize(Roles = UserRoles.ADMIN)]
        [HttpGet("type")]
        public async Task<JsonResult> GetNumberOfResultsByTypeAsync(ResultTypes resultType)
        {
            try
            {
                var number = await _statisticsService.GetNumberOfResultsByTypeAsync(resultType);
                return Json(number);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in {nameof(GetNumberOfResultsByTypeAsync)}; Exception: {ex.Message}, stack trace: {ex.StackTrace}");
                return Json(ex.Message);
            }
        }

        [Authorize(Roles = UserRoles.ADMIN)]
        [HttpGet("user")]
        public async Task<JsonResult> GetNumberOfResultsByUserAsync(string userId)
        {
            try
            {
                var number = await _statisticsService.GetNumberOfResultsByUserAsync(userId);
                return Json(number);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in {nameof(GetNumberOfResultsByUserAsync)}; Exception: {ex.Message}, stack trace: {ex.StackTrace}");
                return Json(ex.Message);
            }
        }

        [Authorize(Roles = UserRoles.ADMIN)]
        [HttpGet("score")]
        public async Task<JsonResult> GetNumberOfResultsByScoreAsync(short startScore, short endScore)
        {
            try
            {
                var number = await _statisticsService.GetNumberOfResultsByScoreAsync(startScore, endScore);
                return Json(number);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in {nameof(GetNumberOfResultsByScoreAsync)}; Exception: {ex.Message}, stack trace: {ex.StackTrace}");
                return Json(ex.Message);
            }
        }

        [Authorize(Roles = UserRoles.ADMIN)]
        [HttpGet("average")]
        public async Task<JsonResult> GetAverageScoreAsync()
        {
            try
            {
                var number = await _statisticsService.GetAverageScoreAsync();
                return Json(number);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in {nameof(GetAverageScoreAsync)}; Exception: {ex.Message}, stack trace: {ex.StackTrace}");
                return Json(ex.Message);
            }
        }
    }
}