using System.ComponentModel.DataAnnotations;

namespace WebApp.Models;

public class SubscribeViewModel
{
    [Required]
    [Display(Name = "Email", Prompt = "Your Email")]
    public string Email { get; set; } = null!;

    [Display(Name = "Daily Newletter")]
    public bool DailyNewsletter { get; set; } 

    [Display(Name = "Advertising Updates")]
    public bool AdvertisingUpdates { get; set; } 

    [Display(Name = "Week in Review")]
    public bool WeekInReview { get; set; }

    [Display(Name = "Event Updates")]
    public bool EventUpdates { get; set; }

    [Display(Name = "Startups Weekly")]
    public bool StartUpsWeekly { get; set; } 

    [Display(Name = "Podcasts")]
    public bool Podcasts { get; set; }

    //[Display(Name = "I agree to the Terms & Conditions.>")]
    //[CheckBoxRequired(ErrorMessage = "You must accept the terms and conditions.")]
    //public bool IsSubscribed { get; set; } = false;
}
