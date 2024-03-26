using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Infrastructure.Entities;

public class ProgramDetailsEntity
{
    [Key]
    public int SectionId { get; set; }

    [ForeignKey(nameof(Course))]
    public int CourseId { get; set; }

    public int ProgramDetailsNumber { get; set; }
    public string ProgramDetailsTitle { get; set; } = null!;
    public string? ProgramDetailsDescription { get; set; }
    public CourseEntity? Course { get; set; }
}
