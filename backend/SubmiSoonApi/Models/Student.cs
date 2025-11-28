namespace SubmiSoonApi.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
        public string PasswordHash { get; set; } = "";

        public ICollection<Attempt> Attempts { get; set; } = new List<Attempt>();
    }
}