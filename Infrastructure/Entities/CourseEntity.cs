using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entities;

public class CourseEntity
{
    [Key]
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

    public int CreatorId { get; set; }
    public CreatorEntity? Creator { get; set; }

    public int CategoryId { get; set; }
    public CategoryEntity? Category { get; set; }

    public CourseDetailsEntity? Details { get; set; }
    public List<ProgramDetailsEntity>? ProgramDetails { get; set; }
    public List<LearningDetailsEntity>? LearningDetails { get; set; }

}
