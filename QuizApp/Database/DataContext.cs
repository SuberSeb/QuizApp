using Microsoft.EntityFrameworkCore;
using QuizApp.Backend.Library.Models;

namespace QuizApp.Backend.Library.Database
{
    public class DataContext : DbContext
    {
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Result> Results { get; set; }

        public DataContext(DbContextOptions<DataContext> dbContextOptions) : base(dbContextOptions)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Quiz>()
                .HasKey(q => q.QuizId);
            modelBuilder.Entity<Quiz>()
                .Property(q => q.QuizId).ValueGeneratedOnAdd();

            modelBuilder.Entity<Question>()
                .HasKey(q => q.QuestionId);
            modelBuilder.Entity<Question>()
                .Property(q => q.QuestionId).ValueGeneratedOnAdd();
            modelBuilder.Entity<Question>()
                .HasOne(q => q.Quiz)
                .WithMany(q => q.Questions)
                .HasForeignKey(q => q.QuizId);

            modelBuilder.Entity<Answer>()
                .HasKey(a => a.AnswerId);
            modelBuilder.Entity<Answer>()
                .Ignore(a => a.IsChecked);
            modelBuilder.Entity<Answer>()
                .Property(a => a.AnswerId).ValueGeneratedOnAdd();
            modelBuilder.Entity<Answer>()
                .HasOne(a => a.Question)
                .WithMany(q => q.Answers)
                .HasForeignKey(a => a.QuestionId);

            modelBuilder.Entity<Result>()
                .HasKey(r => r.ResultId);
            modelBuilder.Entity<Result>()
                .Property(r => r.ResultId).ValueGeneratedOnAdd();
            modelBuilder.Entity<Result>()
                .HasOne(r => r.Quiz)
                .WithMany(q => q.Results)
                .HasForeignKey(r => r.QuizId);
        }
    }
}