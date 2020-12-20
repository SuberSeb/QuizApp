using System;
using System.Text.Json.Serialization;
using static QuizApp.Backend.Library.Models.Enums.ResultTypeEnum;

namespace QuizApp.Backend.Library.Models
{
    public sealed class Result
    {
        public int ResultId { get; set; }
        public short TotalScore { get; set; }
        public ResultTypes ResultType { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string UserId { get; set; }

        [JsonIgnore]
        public Quiz Quiz { get; set; }

        public int QuizId { get; set; }
    }
}