namespace SubmiSoonApi.Models
{
    public class Question {
        public int QuestionId {get;set;}

        public string QuestionText {get;set;} = "";
        public QuestionType QuestionType {get;set;}

        public ICollection<Choice> Choices {get;set;} = new List<Choice>();
        public int? CorrectChoiceId {get; set;}
        public Choice? CorrectChoice {get;set;}
    
    }
}