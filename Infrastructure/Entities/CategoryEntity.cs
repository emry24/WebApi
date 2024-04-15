using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Entities;

public class CategoryEntity
{
    [Key]
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public List<CourseEntity>? Courses { get; set; }
}
