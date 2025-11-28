namespace SubmiSoonApi.Dtos
{
    public class LeaderboardItemDto
    {
        public int Rank {get; set;}
        public int StudentId {get; set;}
        public string Name {get;set;} = "";
        public int TotalCompleted {get;set;}
        public int TotalAssigned {get;set;}
    }
}