using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Infrastructure.Entities
{
    public class CourseDetails
    {
        [Key]
        public int CourseDetailsId { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }

        public int NumberOfArticles { get; set; }
        public int NumberOfResources { get; set; }
        public bool LifetimeAccess { get; set; }
        public bool Certificate { get; set; }

        public decimal Price { get; set; }
        public decimal DiscountedPrice { get; set; }

        public Course? Course { get; set; }
    }
}
