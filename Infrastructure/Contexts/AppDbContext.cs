using Microsoft.EntityFrameworkCore;
using Infrastructure.Entities;

namespace Infrastructure.Contexts
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<CourseEntity> Courses { get; set; }
        public DbSet<SubscriberEntity> Subscribers { get; set; }

    }
}
