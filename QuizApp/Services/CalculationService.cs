using QuizApp.Backend.Library.Models;
using QuizApp.Backend.Library.Services.Interfaces;
using static QuizApp.Backend.Library.Models.Enums.ResultTypeEnum;

namespace QuizApp.Backend.Library.Services
{
    public class CalculationService : ICalculationService
    {
        public short CalcQuizScore(Quiz quiz)
        {
            short score = 0;
            var answersAdded = 0;

            if (quiz != null)
            {
                foreach (var question in quiz.Questions)
                {
                    foreach (var answer in question.Answers)
                    {
                        if (answer.IsChecked)
                        {
                            score += answer.Score;
                            answersAdded++;
                        }
                    }
                }
            }

            if (quiz.Questions.Count != answersAdded)
            {
                score = 0;
            }

            return score;
        }

        public ResultTypes GetQuizResultType(short score)
        {
            if (score < (short)ResultTypes.Indefined)
            {
                return ResultTypes.Indefined;
            }
            else if (score > (short)ResultTypes.Indefined && score < (short)ResultTypes.Integrated)
            {
                return ResultTypes.Integrated;
            }
            else if (score > (short)ResultTypes.Integrated && score < (short)ResultTypes.LeftHemispheric)
            {
                return ResultTypes.LeftHemispheric;
            }
            else if (score > (short)ResultTypes.LeftHemispheric && score < (short)ResultTypes.RightHemispheric)
            {
                return ResultTypes.RightHemispheric;
            }
            else
            {
                return ResultTypes.Indefined;
            }
        }
    }
}