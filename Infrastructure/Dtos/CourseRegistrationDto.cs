using Infrastructure.Entities;


namespace Infrastructure.Dtos;

public class CourseRegistrationDto
{
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
    public decimal Price { get; set; }
    public decimal DiscountedPrice { get; set; }


    public string LearningsDescription { get; set; } = null!;
    public int ProgramDetailsNumber { get; set; }
    public string ProgramDetailsTitle { get; set; } = null!;
    public string? ProgramDetailsDescription { get; set; }


    public string CategoryName { get; set; } = null!;

    public string CreatorName { get; set; } = null!;
    public string? CreatorBio { get; set; }
    public string? YoutubeSubscribers { get; set; }
    public string? FacebookFollowers { get; set; }
    public string? CreatorImage { get; set; }

    //public static implicit operator CourseEntity(CourseRegistrationDto form)
    //{
    //    return new CourseEntity
    //    {
    //        Title = form.Title,
    //        Ingress = form.Ingress,
    //        IsBestseller = form.IsBestseller,
    //        Reviews = form.Reviews,
    //        RatingImage = form.RatingImage,
    //        LikesInProcent = form.LikesInProcent,
    //        LikesInNumbers = form.LikesInNumbers,
    //        DurationHours = form.DurationHours,
    //        Description = form.Description
    //    };
    //}

    //public static implicit operator CourseDetailsEntity(CourseRegistrationDto form)
    //{
    //    return new CourseDetailsEntity
    //    {
    //        NumberOfArticles = form.NumberOfArticles,
    //        NumberOfResources = form.NumberOfResources,
    //        LifetimeAccess = form.LifetimeAccess,
    //        Certificate = form.Certificate,
    //        Price = form.Price,
    //        DiscountedPrice = form.DiscountedPrice
    //    };
    //}

    //public static implicit operator CategoryEntity(CourseRegistrationDto form)
    //{
    //    return new CategoryEntity
    //    {
    //        CategoryName = form.CategoryName
    //    };
    //}

    //public static implicit operator CreatorEntity(CourseRegistrationDto form)
    //{
    //    return new CreatorEntity
    //    {
    //        CreatorName = form.CreatorName,
    //        CreatorBio = form.CreatorBio,
    //        YoutubeSubscribers = form.YoutubeSubscribers,
    //        FacebookFollowers = form.FacebookFollowers,
    //        CreatorImage = form.CreatorImage
    //    };
    //}

    //public static implicit operator LearningDetailsEntity(CourseRegistrationDto form)
    //{
    //    return new LearningDetailsEntity
    //    {
    //        LearningsDescription = form.LearningsDescription
    //    };
    //}

    //public static implicit operator ProgramDetailsEntity(CourseRegistrationDto form)
    //{
    //    return new ProgramDetailsEntity
    //    {
    //        ProgramDetailsNumber = form.ProgramDetailsNumber,
    //        ProgramDetailsTitle = form.ProgramDetailsTitle,
    //        ProgramDetailsDescription = form.ProgramDetailsDescription
    //    };
    //}
}
