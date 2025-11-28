public class AnswerDto
{
    public int? AnswerId {get;set;}
    public int QuestionId {get; set;}
    public string Type { get; set; } = ""; // "essay", "mcq", "file"
    public string? EssayAnswer { get; set; }
    public int? ChoosenId { get; set; }
    public string? FilePath { get; set; }
    public DateTime? LastUpdated {get; set;}
}