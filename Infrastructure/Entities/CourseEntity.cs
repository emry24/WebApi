using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Entities;

public class Course
{
    [Key]
    public int CourseId { get; set; }

    public string Title { get; set; } = null!;
    public string? Ingress { get; set; }
    public bool IsBestseller { get; set; }
    public int Reviews { get; set; }
    public string? RatingImage { get; set; }
    public int Likes { get; set; }
    public int DurationHours { get; set; }
    public string? Description { get; set; }


    public int CreatorId { get; set; }
    public Creator? Creator { get; set; }

    public int CategoryId { get; set; }
    public Category? Category { get; set; }

    public CourseDetails? Details { get; set; }
    public List<ProgramDetails>? ProgramDetails { get; set; }
    public List<LearningDetails>? LearningDetails { get; set; }

    //public List<CourseTag>? Tags { get; set; }

}
