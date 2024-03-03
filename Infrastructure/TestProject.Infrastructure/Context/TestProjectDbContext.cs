using Microsoft.EntityFrameworkCore;
using TestProject.Domain.Entities;

namespace TestProject.Infrastructure.Context
{
    public class TestProjectDbContext : DbContext
    {
        public TestProjectDbContext(DbContextOptions<TestProjectDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
