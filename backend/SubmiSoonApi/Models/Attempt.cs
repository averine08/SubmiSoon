namespace SubmiSoonApi.Models
{
    public class Attempt
    {
        public int AttemptId { get; set; }  

        public int StudentId { get; set; }
        public Student Student { get; set; } = null!;

        public int AssessmentId { get; set; }
        public Assessment Assessment { get; set; } = null!;

        public DateTime? SubmittedAt { get; set; }

        public AttemptStatus Status { get; set; } = AttemptStatus.NotStarted;

        public ICollection<Answer> Answers { get; set; } = new List<Answer>();

        public int? Score { get; set; }
    }
}
