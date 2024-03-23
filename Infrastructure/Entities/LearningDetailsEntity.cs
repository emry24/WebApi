using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Infrastructure.Entities;

public class LearningDetails
{
    [Key]
    public int LearningsId { get; set; }

    [ForeignKey("Course")]
    public int CourseId { get; set; }

    public string Description { get; set; } = null!;

    public Course? Course { get; set; }
}
