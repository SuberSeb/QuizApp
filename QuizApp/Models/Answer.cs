using System.Text.Json.Serialization;

namespace QuizApp.Backend.Library.Models
{
    public sealed class Answer
    {
        public int AnswerId { get; set; }
        public string Title { get; set; }
        public byte Score { get; set; }
        public bool IsChecked { get; set; }

        [JsonIgnore]
        public Question Question { get; set; }

        public int QuestionId { get; set; }
    }
}