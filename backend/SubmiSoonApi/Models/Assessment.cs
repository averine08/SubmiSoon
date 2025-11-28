namespace SubmiSoonApi.Models
{
    public class Assessment
    {
        public int AssessmentId { get; set; }   

        public string Title {get; set;} = "";
        public string Description {get; set;} = "";
        // public int TotalQuestion {get;set;}

        public DateTime StartDate {get;set;} 
        public DateTime EndDate {get;set;} 

        public ICollection<Question> Questions {get;set;} = new List<Question>();


    }
}
