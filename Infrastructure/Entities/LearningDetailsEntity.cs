using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Infrastructure.Entities;

public class LearningDetailsEntity
{
    [Key]
    public int LearningsId { get; set; }

    [ForeignKey(nameof(Course))]
    public int CourseId { get; set; }

    public string LearningsDescription { get; set; } = null!;

    public CourseEntity? Course { get; set; }
}
