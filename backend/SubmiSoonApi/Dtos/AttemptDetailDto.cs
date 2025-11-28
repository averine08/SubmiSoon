using SubmiSoonApi.Models;

namespace SubmiSoonApi.Dtos
{
    public class AttemptDetailDto
    {
        public int AttemptId {get; set;}
        public int AssesmentId {get; set;}
        public AttemptStatus Status {get; set;}
        public string AsgTitle {get; set;} = "";
        public DateTime StartDate {get; set;}
        public DateTime EndDate {get;set;}
        public ICollection<QuestionDto> Questions {get; set;} = new List<QuestionDto>();

        public ICollection<AnswerDto> Answers {get; set;} = new List<AnswerDto>();

    }

}