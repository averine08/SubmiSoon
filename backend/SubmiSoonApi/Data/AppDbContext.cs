using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SubmiSoonApi.Models;

namespace SubmiSoonApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        
        }

        // DbSet = representasi tabel
        public DbSet<Student> Students { get; set; }
        public DbSet<Assessment> Assessments { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Choice> Choices { get; set; }
        public DbSet<Attempt> Attempts { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<StudentStat> StudentStats { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
    
            foreach(var fk in modelBuilder.Model.GetEntityTypes()
            .SelectMany(e => e.GetForeignKeys()))
            {
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            }

            // Konfigurasi untuk CorrectOptionId (Relasi ke Opsi yang Benar)
            // Ini adalah relasi one-to-one opsional antara Question dan MultipleChoiceOption
            modelBuilder.Entity<Question>()
                .HasOne(q => q.CorrectChoice)
                .WithMany()
                .HasForeignKey(q => q.CorrectChoiceId)
                .IsRequired(false); // Relasi ini opsional karena hanya digunakan untuk MCQ
                
            
            // Mapping enum QuestionType ke string di database
            // Ini agar nilai enum (MultipleChoice, Essay) disimpan sebagai teks
            modelBuilder.Entity<Question>()
                .Property(q => q.QuestionType)
                .HasConversion<string>();

            base.OnModelCreating(modelBuilder);
        }
    }
}