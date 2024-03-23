using System.ComponentModel.DataAnnotations;


namespace Infrastructure.Entities;

public class Creator
{
    //[Key]
    public int CreatorId { get; set; }

    public string Name { get; set; } = null!;
    public string? Bio { get; set; }
    public int YoutubeSubscribers { get; set; }
    public int FacebookFollowers { get; set; }
    public string? ProfileImage { get; set; }

    public List<Course>? Courses { get; set; }
}
