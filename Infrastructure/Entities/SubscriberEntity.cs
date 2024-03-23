using Infrastructure.Dtos;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Entities;

public class SubscriberEntity
{
    public int Id { get; set; }

    //public string Id {  get; set; } = Guid.NewGuid().ToString();

    [Required]
    public string Email { get; set; } = null!;
    public bool DailyNewsletter { get; set; } = false;
    public bool AdvertisingUpdates { get; set; } = false;
    public bool WeekInReview { get; set; } = false;
    public bool EventUpdates { get; set; } = false;
    public bool StartUpsWeekly { get; set; } = false;
    public bool Podcasts { get; set; } = false;

    //public static implicit operator SubscriberEntity(SubscriberDto dto)
    //{
    //    return new SubscriberEntity
    //    {
    //        Email = dto.Email,
    //        DailyNewsletter = dto.DailyNewsletter,
    //        AdvertisingUpdates = dto.AdvertisingUpdates,
    //        WeekInReview = dto.WeekInReview,
    //        EventUpdates = dto.EventUpdates,
    //        StartUpsWeekly = dto.StartUpsWeekly,
    //        Podcasts = dto.Podcasts
    //    };
    //}
}
