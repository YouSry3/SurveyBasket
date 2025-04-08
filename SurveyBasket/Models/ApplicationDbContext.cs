using Microsoft.EntityFrameworkCore;
using SurveyBasket.EntitiesConfigrartions;
using System.Reflection;

namespace SurveyBasket.Entities
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
       public DbSet<Poll> Polls { get; set; }

       protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
