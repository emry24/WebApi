using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Infrastructure.Entities;

public class ProgramDetails
{
    [Key]
    public int SectionId { get; set; }

    [ForeignKey("Course")]
    public int CourseId { get; set; }
    public int SectionNumber { get; set; }
    public string SectionTitle { get; set; } = null!;
    public string? SectionDescription { get; set; }

    public Course? Course { get; set; }
}
