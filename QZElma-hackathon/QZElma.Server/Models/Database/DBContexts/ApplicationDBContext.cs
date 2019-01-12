using Microsoft.EntityFrameworkCore;
using QZElma.Server.Models.Database.DBEntities;


namespace QZElma.Server.Models.Database.DBContexts
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<Quiz> Quizzes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
