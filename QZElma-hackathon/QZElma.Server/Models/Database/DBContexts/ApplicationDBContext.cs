using Microsoft.EntityFrameworkCore;
using QZElma.Server.Models.Database.DBEntities;
using System;


namespace QZElma.Server.Models.Database.DBContexts
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
            _guid = Guid.NewGuid();
        }

        private Guid _guid { get; set; }


        public DbSet<User> Users { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<Quiz> Quizzes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
