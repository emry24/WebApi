//using Infrastructure.Dtos;
//using Infrastructure.Entities;

//namespace Infrastructure.Factories;

//public class CourseDetailsFactory
//{
//    public static CourseDetailsDto Create(CourseDetailsEntity entity)
//    {
//        try
//        {
//            return new CourseDetailsDto
//            {
//                NumberOfArticles = entity.NumberOfArticles,
//                NumberOfResources = entity.NumberOfResources,
//                LifetimeAccess = entity.LifetimeAccess,
//                Certificate = entity.Certificate,
//                Price = entity.Price,
//                DiscountedPrice = entity.DiscountedPrice,
//            };
//        }
//        catch { }
//        return null!;
//    }

//    public static IEnumerable<CourseDetailsDto> Create(List<CourseDetailsEntity> entities)
//    {
//        List<CourseDetailsDto> courseDetails = [];

//        try
//        {
//            foreach (var entity in entities)
//                courseDetails.Add(Create(entity));
//        }
//        catch { }
//        return courseDetails;
//    }
//}
