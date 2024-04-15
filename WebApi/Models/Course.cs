using Infrastructure.Entities;

namespace WebApi.Models;

public class Course
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string? Ingress { get; set; }
    public bool IsBestseller { get; set; }
    public string? Reviews { get; set; }
    public string? RatingImage { get; set; }
    public string? LikesInProcent { get; set; }
    public string? LikesInNumbers { get; set; }
    public int DurationHours { get; set; }
    public string? Description { get; set; }
    public int NumberOfArticles { get; set; }
    public int NumberOfResources { get; set; }
    public bool LifetimeAccess { get; set; }
    public bool Certificate { get; set; }

    //public string LearningsDescription { get; set; } = null!;
    //public int ProgramDetailsNumber { get; set; }
    //public string ProgramDetailsTitle { get; set; } = null!;
    //public string? ProgramDetailsDescription { get; set; }

    public decimal Price { get; set; }
    public decimal DiscountedPrice { get; set; }
    public string CategoryName { get; set; } = null!;

    public string CreatorName { get; set; } = null!;
    public string? CreatorBio { get; set; }
    public string? YoutubeSubscribers { get; set; }
    public string? FacebookFollowers { get; set; }
    public string? CreatorImage { get; set; }

    public static implicit operator Course(CourseEntity courseEntity)
    {
        return new Course
        {
            Id = courseEntity.CourseId,
            Title = courseEntity.Title,
            Ingress = courseEntity.Ingress,
            IsBestseller = courseEntity.IsBestseller,
            Reviews = courseEntity.Reviews,
            RatingImage = courseEntity.RatingImage,
            LikesInProcent = courseEntity.LikesInProcent,
            LikesInNumbers = courseEntity.LikesInNumbers,
            DurationHours = courseEntity.DurationHours,
            Description = courseEntity.Description,
        };
    }

    public static implicit operator Course(CourseDetailsEntity courseDetailsEntity)
    {
        return new Course
        {
            NumberOfArticles = courseDetailsEntity.NumberOfArticles,
            NumberOfResources = courseDetailsEntity.NumberOfResources,
            LifetimeAccess = courseDetailsEntity.LifetimeAccess,
            Certificate = courseDetailsEntity.Certificate,
            Price = courseDetailsEntity.Price,
            DiscountedPrice = courseDetailsEntity.DiscountedPrice,
        };
    }

    public static implicit operator Course(CategoryEntity categoryEntity)
    {
        return new Course
        {
            CategoryName = categoryEntity.CategoryName,
        };
    }

    public static implicit operator Course(CreatorEntity creatorEntity)
    {
        return new Course
        {
            CreatorName = creatorEntity.CreatorName,
            CreatorBio = creatorEntity.CreatorBio,
            YoutubeSubscribers = creatorEntity.YoutubeSubscribers,
            FacebookFollowers = creatorEntity.FacebookFollowers,
            CreatorImage = creatorEntity.CreatorImage,
        };
    }

    //public static implicit operator Course(LearningDetailsEntity learningDetailsEntity)
    //{
    //    return new Course
    //    {
    //        LearningsDescription = learningDetailsEntity.LearningsDescription,
    //    };
    //}

    //public static implicit operator Course(ProgramDetailsEntity programDetailsEntity)
    //{
    //    return new Course
    //    {
    //        ProgramDetailsNumber = programDetailsEntity.ProgramDetailsNumber,
    //        ProgramDetailsTitle = programDetailsEntity.ProgramDetailsTitle,
    //        ProgramDetailsDescription = programDetailsEntity.ProgramDetailsDescription,
    //    };
    //}
}
