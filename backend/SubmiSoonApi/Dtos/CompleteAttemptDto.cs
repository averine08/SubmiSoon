using System.Runtime.CompilerServices;

namespace SubmiSoonApi.Dtos
{
    public class CompleteAttemptDto
    {
        public int AttemptId {get;set;}
        public int AssessmentId {get; set;}
        public string Title {get; set;} = "";
        public string Description {get;set;} = "";
        public string Status {get; set;} = "";
        public DateTime? SubmittedAt {get; set;}
        public int? Score {get; set;}
    }
    
}