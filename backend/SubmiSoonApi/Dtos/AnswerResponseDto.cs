namespace SubmiSoonApi.Dtos
{
    // public class SubmitAttemptDto
    // {
    //     public List<SubmitAnswerDto> Answers { get; set; } = new();
    // }

    public class SubmitAnswerDto
    {
        public int QuestionId { get; set; }
        public string Type { get; set; } = string.Empty; // "essay" | "mcq" | "file"
        public string? EssayAnswer { get; set; }
        public int? ChooosenId { get; set; }
        public string? FilePath { get; set; }
        public DateTime? LastUpdated {get; set;}
    }
    

}
