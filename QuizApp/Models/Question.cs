using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace QuizApp.Backend.Library.Models
{
    public sealed class Question
    {
        public int QuestionId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Answer> Answers { get; set; }

        [JsonIgnore]
        public Quiz Quiz { get; set; }

        public int QuizId { get; set; }

        public int AnswersNumber => Answers is null ? 0 : Answers.Count;
    }
}