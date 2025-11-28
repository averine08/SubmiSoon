using SubmiSoonApi.Models;

namespace SubmiSoonApi.Dtos
{
    public class QuestionDto {
        public int QuestionId {get;set;}
        public string QuestionText {get;set;} = "";
        public QuestionType QuestionType {get;set;}
        public ICollection<ChoiceDto> Choices {get;set;} = new List<ChoiceDto>();
    
    }
}