using Domain.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace Domain.DataAccess
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Application> Applications { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(
                "Server=(localdb)\\mssqllocaldb;Database=SchoolDatabase1;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}
