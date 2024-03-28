namespace Infrastructure.Dtos;

public class CourseDto
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
}
