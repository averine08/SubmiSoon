namespace SubmiSoonApi.Models
{
    public class Answer
    {
        public int AnswerId {get;set;}

        public int AttemptId {get;set;}
        public Attempt Attempt {get;set;} = null!;

        public int QuestionId {get;set;}
        public Question Question {get;set;} = null!;

        public DateTime? LastUpdated{get;set; }
        public AnswerStatus AnswerStatus {get;set;} = AnswerStatus.NotAnswered;
    
        public string? EssayAnswer {get;set;}
        public int? ChosenAnswerId {get;set;}
        public string? FilePath {get;set;}
        
        public int? Score {get;set;}
    }
}
