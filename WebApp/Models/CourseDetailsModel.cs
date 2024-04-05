namespace WebApp.Models;

public class CourseDetailsModel
{
    public int NumberOfArticles { get; set; }
    public int NumberOfResources { get; set; }
    public bool LifetimeAccess { get; set; }
    public bool Certificate { get; set; }

    public decimal Price { get; set; }
    public decimal DiscountedPrice { get; set; }
}
