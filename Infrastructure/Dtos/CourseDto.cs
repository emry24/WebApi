using Infrastructure.Entities;

namespace Infrastructure.Dtos;

public class CourseDto
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



    //public CreatorDto? Creator { get; set; }


    public CategoryDto? Category { get; set; }

    public CourseDetailsDto? Details { get; set; }
    public List<ProgramDetailsDto>? ProgramDetails { get; set; }
    public List<LearningDetailsDto>? LearningDetails { get; set; }
}
