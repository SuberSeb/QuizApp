using QuizApp.Backend.Library.Models;
using static QuizApp.Backend.Library.Models.Enums.ResultTypeEnum;

namespace QuizApp.Backend.Library.Services.Interfaces
{
    public interface ICalculationService
    {
        short CalcQuizScore(Quiz quiz);

        ResultTypes GetQuizResultType(short score);
    }
}