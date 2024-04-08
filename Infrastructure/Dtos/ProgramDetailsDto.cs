namespace Infrastructure.Dtos;

public class ProgramDetailsDto
{
    public int ProgramDetailsNumber { get; set; }
    public string ProgramDetailsTitle { get; set; } = null!;
    public string? ProgramDetailsDescription { get; set; }
}
