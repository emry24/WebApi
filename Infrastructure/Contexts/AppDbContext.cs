using Microsoft.EntityFrameworkCore;
using Infrastructure.Entities;

namespace Infrastructure.Contexts;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public virtual DbSet<ContactEntity> Contacts { get; set; }
    public virtual DbSet<SubscriberEntity> Subscribers { get; set; }
    public virtual DbSet<CreatorEntity> Creators { get; set; }
    public virtual DbSet<CourseEntity> Courses { get; set; }
    public virtual DbSet<CourseDetailsEntity> CourseDetails { get; set; }
    public virtual DbSet<ProgramDetailsEntity> ProgramDetails { get; set; }
    public virtual DbSet<LearningDetailsEntity> LearningDetails { get; set; }
    public virtual DbSet<CategoryEntity> Categories { get; set; }
    //public virtual DbSet<TagEntity> Tags { get; set; }
    //public virtual DbSet<CourseTagEntity> CourseTags { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CourseEntity>()
            .HasOne(x => x.Creator)
            .WithMany(x => x.Courses)
            .HasForeignKey(x => x.CreatorId);

        modelBuilder.Entity<CourseEntity>()
            .HasOne(x => x.Category)
            .WithMany(x => x.Courses)
            .HasForeignKey(x => x.CategoryId);

        modelBuilder.Entity<CourseDetailsEntity>()
            .HasKey(x => x.CourseDetailsId);

        modelBuilder.Entity<CourseEntity>()
            .HasOne(x => x.Details)
            .WithOne(x => x.Course)
            .HasForeignKey<CourseDetailsEntity>(x => x.CourseId);

        modelBuilder.Entity<ProgramDetailsEntity>()
            .HasOne(x => x.Course)
            .WithMany(x => x.ProgramDetails)
            .HasForeignKey(x => x.CourseId);

        modelBuilder.Entity<LearningDetailsEntity>()
            .HasOne(x => x.Course)
            .WithMany(x => x.LearningDetails)
            .HasForeignKey(x => x.CourseId);

        modelBuilder.Entity<CourseDetailsEntity>()
            .Property(x => x.Price)
            .HasColumnType("decimal(18, 2)");

        modelBuilder.Entity<CourseDetailsEntity>()
            .Property(x => x.DiscountedPrice)
            .HasColumnType("decimal(18, 2)");


        //modelBuilder.Entity<CourseTagEntity>()
        //    .HasKey(ct => new { ct.CourseId, ct.TagId });

        //modelBuilder.Entity<CourseTagEntity>()
        //    .HasOne(ct => ct.Course)
        //    .WithMany(c => c.Tags)
        //    .HasForeignKey(ct => ct.CourseId);

        //modelBuilder.Entity<CourseTagEntity>()
        //    .HasOne(ct => ct.Tag)
        //    .WithMany()
        //    .HasForeignKey(ct => ct.TagId);
    }
}
