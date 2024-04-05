using Infrastructure.Entities;

namespace WebApp.Models;

public class CourseViewModel
{
    public IEnumerable<CourseModel> Courses { get; set; } = [];

}



