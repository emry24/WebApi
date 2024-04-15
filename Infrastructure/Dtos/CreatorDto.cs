namespace Infrastructure.Dtos;

public class CreatorDto
{
    public int CreatorId { get; set; }
    public string CreatorName { get; set; } = null!;
    public string? CreatorBio { get; set; }
    public string? YoutubeSubscribers { get; set; }
    public string? FacebookFollowers { get; set; }
    public string? CreatorImage { get; set; }
}
