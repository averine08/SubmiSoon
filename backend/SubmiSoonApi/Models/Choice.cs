namespace SubmiSoonApi.Models
{
    public class Choice{
        public int ChoiceId { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; } = null!;
        public string Text { get; set; } = "";
        
    }

}