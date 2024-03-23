using Microsoft.EntityFrameworkCore;
using Infrastructure.Entities;

namespace Infrastructure.Contexts;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{

    public virtual DbSet<SubscriberEntity> Subscribers { get; set; }
    public virtual DbSet<Creator> Creators { get; set; }
    public virtual DbSet<Course> Courses { get; set; }
    public virtual DbSet<CourseDetails> CourseDetails { get; set; }
    public virtual DbSet<ProgramDetails> ProgramDetails { get; set; }
    public virtual DbSet<LearningDetails> LearningDetails { get; set; }
    public virtual DbSet<Category> Categories { get; set; }

    //public DbSet<Tag> Tags { get; set; }
    //public DbSet<CourseTag> CourseTags { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>()
            .HasOne(x => x.Creator)
            .WithMany(x => x.Courses)
            .HasForeignKey(x => x.CreatorId);

        modelBuilder.Entity<Course>()
            .HasOne(x => x.Category)
            .WithMany(x => x.Courses)
            .HasForeignKey(x => x.CategoryId);

            modelBuilder.Entity<CourseDetails>()
            .HasKey(cd => cd.CourseDetailsId);

        modelBuilder.Entity<Course>()
            .HasOne(x => x.Details)
            .WithOne(x => x.Course)
            .HasForeignKey<CourseDetails>(x => x.CourseId);

        modelBuilder.Entity<ProgramDetails>()
            .HasOne(x => x.Course)
            .WithMany(x => x.ProgramDetails)
            .HasForeignKey(x => x.CourseId);

        modelBuilder.Entity<LearningDetails>()
            .HasOne(x => x.Course)
            .WithMany(x => x.LearningDetails)
            .HasForeignKey(x => x.CourseId);

        modelBuilder.Entity<CourseDetails>()
            .Property(x => x.Price)
            .HasColumnType("decimal(18, 2)");

        modelBuilder.Entity<CourseDetails>()
            .Property(x => x.DiscountedPrice)
            .HasColumnType("decimal(18, 2)");


        //modelBuilder.Entity<CourseTag>()
        //    .HasKey(ct => new { ct.CourseId, ct.TagId });

        //modelBuilder.Entity<CourseTag>()
        //    .HasOne(ct => ct.Course)
        //    .WithMany(c => c.CourseTags)
        //    .HasForeignKey(ct => ct.CourseId);

        //modelBuilder.Entity<CourseTag>()
        //    .HasOne(ct => ct.Tag)
        //    .WithMany()
        //    .HasForeignKey(ct => ct.TagId);
    }
}
