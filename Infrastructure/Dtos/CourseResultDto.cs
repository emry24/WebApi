namespace Infrastructure.Dtos;

public class CourseResultDto
{
    public bool Succeeded { get; set; }
    public IEnumerable<CourseDto>? Courses { get; set; }
}
