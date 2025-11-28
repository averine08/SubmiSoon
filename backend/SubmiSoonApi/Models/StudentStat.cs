namespace SubmiSoonApi.Models
{
    public class StudentStat
    {
        public int StudentStatId {get;set;}
        public int StudentId {get;set;}
        public int TotalCompleted {get;set;}
        public DateTime LastUpdated {get;set;}
    }
}