using Infrastructure.Dtos;
using Infrastructure.Entities;
using WebApi.Models;

namespace WebApp.Models;

public class CourseModel
{
    public int CourseId { get; set; }
    public string Title { get; set; } = null!;
    public string? Ingress { get; set; }
    public bool IsBestseller { get; set; }
    public string? Reviews { get; set; }
    public string? RatingImage { get; set; }
    public string? LikesInProcent { get; set; }
    public string? LikesInNumbers { get; set; }

    public int DurationHours { get; set; }
    public string? Description { get; set; }

    public CreatorModel? Creator { get; set; }
    public CategoryModel? Category { get; set; }
    public CourseDetailsModel? Details { get; set; }
    public List<ProgramDetailsModel>? ProgramDetails { get; set; }
    public List<LearningDetailsModel>? LearningDetails { get; set; }
}
