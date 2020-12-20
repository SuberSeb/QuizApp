using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace QuizApp.Backend.Library.Models
{
    public sealed class Quiz
    {
        public int QuizId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<Question> Questions { get; set; }

        [JsonIgnore]
        public List<Result> Results { get; set; }

        public int QuestionsNumber => Questions is null ? 0 : Questions.Count;
        public int PassedTestsNumber => Results is null ? 0 : Results.Count;
    }
}