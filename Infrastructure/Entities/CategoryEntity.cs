using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Entities;

public class Category
{
    //[Key]
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public List<Course>? Courses { get; set; }
}
