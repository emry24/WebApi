using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dtos;

public class CreatorDto
{
    public string CreatorName { get; set; } = null!;
    public string? CreatorBio { get; set; }
    public string? YoutubeSubscribers { get; set; }
    public string? FacebookFollowers { get; set; }
    public string? CreatorImage { get; set; }
}
