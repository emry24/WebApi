using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Dtos;

public class SubscriberDto
{
    [Required]
    public string Email { get; set; } = null!;
    public bool DailyNewsletter { get; set; } = false;
    public bool AdvertisingUpdates { get; set; } = false;
    public bool WeekInReview { get; set; } = false;
    public bool EventUpdates { get; set; } = false;
    public bool StartUpsWeekly { get; set; } = false;
    public bool Podcasts { get; set; } = false;
}
