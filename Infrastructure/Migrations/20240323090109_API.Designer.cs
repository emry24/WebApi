﻿// <auto-generated />
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240323090109_API")]
    partial class API
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Infrastructure.Entities.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Infrastructure.Entities.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseId"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("CreatorId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DurationHours")
                        .HasColumnType("int");

                    b.Property<string>("Ingress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsBestseller")
                        .HasColumnType("bit");

                    b.Property<int>("Likes")
                        .HasColumnType("int");

                    b.Property<string>("RatingImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Reviews")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CourseId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CreatorId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Infrastructure.Entities.CourseDetails", b =>
                {
                    b.Property<int>("CourseDetailsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseDetailsId"));

                    b.Property<bool>("Certificate")
                        .HasColumnType("bit");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<decimal>("DiscountedPrice")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<bool>("LifetimeAccess")
                        .HasColumnType("bit");

                    b.Property<int>("NumberOfArticles")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfResources")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("CourseDetailsId");

                    b.HasIndex("CourseId")
                        .IsUnique();

                    b.ToTable("CourseDetails");
                });

            modelBuilder.Entity("Infrastructure.Entities.Creator", b =>
                {
                    b.Property<int>("CreatorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CreatorId"));

                    b.Property<string>("Bio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FacebookFollowers")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfileImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("YoutubeSubscribers")
                        .HasColumnType("int");

                    b.HasKey("CreatorId");

                    b.ToTable("Creators");
                });

            modelBuilder.Entity("Infrastructure.Entities.LearningDetails", b =>
                {
                    b.Property<int>("LearningsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LearningsId"));

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LearningsId");

                    b.HasIndex("CourseId");

                    b.ToTable("LearningDetails");
                });

            modelBuilder.Entity("Infrastructure.Entities.ProgramDetails", b =>
                {
                    b.Property<int>("SectionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SectionId"));

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<string>("SectionDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SectionNumber")
                        .HasColumnType("int");

                    b.Property<string>("SectionTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SectionId");

                    b.HasIndex("CourseId");

                    b.ToTable("ProgramDetails");
                });

            modelBuilder.Entity("Infrastructure.Entities.SubscriberEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("AdvertisingUpdates")
                        .HasColumnType("bit");

                    b.Property<bool>("DailyNewsletter")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EventUpdates")
                        .HasColumnType("bit");

                    b.Property<bool>("Podcasts")
                        .HasColumnType("bit");

                    b.Property<bool>("StartUpsWeekly")
                        .HasColumnType("bit");

                    b.Property<bool>("WeekInReview")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Subscribers");
                });

            modelBuilder.Entity("Infrastructure.Entities.Course", b =>
                {
                    b.HasOne("Infrastructure.Entities.Category", "Category")
                        .WithMany("Courses")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.Entities.Creator", "Creator")
                        .WithMany("Courses")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("Infrastructure.Entities.CourseDetails", b =>
                {
                    b.HasOne("Infrastructure.Entities.Course", "Course")
                        .WithOne("Details")
                        .HasForeignKey("Infrastructure.Entities.CourseDetails", "CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("Infrastructure.Entities.LearningDetails", b =>
                {
                    b.HasOne("Infrastructure.Entities.Course", "Course")
                        .WithMany("LearningDetails")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("Infrastructure.Entities.ProgramDetails", b =>
                {
                    b.HasOne("Infrastructure.Entities.Course", "Course")
                        .WithMany("ProgramDetails")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("Infrastructure.Entities.Category", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("Infrastructure.Entities.Course", b =>
                {
                    b.Navigation("Details");

                    b.Navigation("LearningDetails");

                    b.Navigation("ProgramDetails");
                });

            modelBuilder.Entity("Infrastructure.Entities.Creator", b =>
                {
                    b.Navigation("Courses");
                });
#pragma warning restore 612, 618
        }
    }
}
