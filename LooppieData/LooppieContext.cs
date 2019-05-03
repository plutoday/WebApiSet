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
            //string azureConnectionString = "Server=tcp:looppiedbtest.database.windows.net,1433;Initial Catalog=lpdbtest;Persist Security Info=False;User ID=lpadmin;Password=Hxm523156!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            string localConnectionString = "Server = MININT-VC4Q4PE; Database = LooppieData; Trusted_Connection = True;";
            optionsBuilder.UseSqlServer(localConnectionString);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
