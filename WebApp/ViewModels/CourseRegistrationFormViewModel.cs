using System.ComponentModel.DataAnnotations;

namespace WebApp.Models;

public class CourseRegistrationFormViewModel
{
    [Required]

    [Display(Name = "Title")]
    public string Title { get; set; } = null!;

    [Display(Name = "Ingress")]
    public string? Ingress { get; set; }

    [Display(Name = "Bestseller")]
    public bool IsBestseller { get; set; }

    [Display(Name = "Reviews")]
    public string? Reviews { get; set; }

    [Display(Name = "Rating image")]
    public string? RatingImage { get; set; }

    [Display(Name = "Likes in procent")]
    public string? LikesInProcent { get; set; }

    [Display(Name = "Likes in numbers")]
    public string? LikesInNumbers { get; set; }

    [Display(Name = "Duration hours")]
    public int DurationHours { get; set; }

    [Display(Name = "Description")]
    public string? Description { get; set; }

    [Display(Name = "Number of articles")]
    public int NumberOfArticles { get; set; }

    [Display(Name = "Number of resources")]
    public int NumberOfResources { get; set; }

    [Display(Name = "Lifetime access")]
    public bool LifetimeAccess { get; set; }

    [Display(Name = "Certificate")]
    public bool Certificate { get; set; }

    [Display(Name = "Price")]
    public decimal Price { get; set; }

    [Display(Name = "Discount")]
    public decimal DiscountedPrice { get; set; }

    [Display(Name = "Category")]
    public string CategoryName { get; set; } = null!;

    [Display(Name = "Creator")]
    public string CreatorName { get; set; } = null!;

    [Display(Name = "Creator bio")]
    public string? CreatorBio { get; set; }

    [Display(Name = "Youtube subscribers")]
    public string? YoutubeSubscribers { get; set; }

    [Display(Name = "Facebook subscribers")]
    public string? FacebookFollowers { get; set; }

    [Display(Name = "Creator image")]
    public string? CreatorImage { get; set; }


    //[Display(Name = "Learning Details")]
    //public List<LearningDetailFormViewModel>? LearningDetails { get; set; }

    //[Display(Name = "Program Details")]
    //public List<ProgramDetailFormViewModel>? ProgramDetails { get; set; }
}



