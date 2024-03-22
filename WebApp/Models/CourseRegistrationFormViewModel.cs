using System.ComponentModel.DataAnnotations;

namespace WebApp.Models;

public class CourseRegistrationFormViewModel
{
    [Required]
    [Display(Name ="Title")]
    public string Title { get; set; } = null!;

    [Display(Name = "Price")]
    public string? Price { get; set; }

    [Display(Name = "Discount Price")]
    public string? DiscountPrice { get; set; }

    [Display(Name = "Hours")]
    public string? Hours { get; set; }

    [Display(Name = "Is a bestseller")]
    public bool IsBestseller { get; set; } = false;

    [Display(Name = "Likes in Numbers")]
    public string? LikesInNumbers { get; set; }

    [Display(Name = "Likes in Procent")]
    public string? LikesInProcent { get; set; }

    [Display(Name = "Author(s)")]
    public string? Author { get; set; }
}
