using Infrastructure.Entities;

namespace WebApp.Models;

public class CourseViewModel
{
    public IEnumerable<CourseModel> Courses { get; set; } = [];

    //public CourseEntity? Course { get; set; }

    //public CategoryEntity? Category { get; set; }
    //public CourseDetailsEntity? Details { get; set; }
    //public CreatorEntity? Creator { get; set; }

    //public LearningDetailsEntity LearningDetails { get; set; }
    //public ProgramDetailsEntity ProgramDetails { get; set; }
}
