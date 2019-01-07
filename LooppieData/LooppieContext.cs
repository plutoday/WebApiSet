using LooppieCore.Domain;
using Microsoft.EntityFrameworkCore;


namespace LooppieCore.Data
{
    public class LooppieContext : DbContext
    {
        public DbSet<Question> Question { get; set; }
        public DbSet<Answer> Answer { get; set; }
        public DbSet<QuestionAnswerRecord> QuestionAnswerRecord { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = LooppieData; Trusted_Connection = True;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
