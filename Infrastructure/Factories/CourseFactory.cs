//using Infrastructure.Dtos;
//using Infrastructure.Entities;

//namespace Infrastructure.Factories;

//public class CourseFactory
//{
//    public static CourseDto Create(CourseEntity entity)
//    {
//        try
//        {
//            return new CourseDto
//            {
//                CourseId = entity.CourseId,
//                Title = entity.Title,
//                Ingress = entity.Ingress,
//                IsBestseller = entity.IsBestseller,
//                Reviews = entity.Reviews,
//                RatingImage = entity.RatingImage,
//                LikesInProcent = entity.LikesInProcent,
//                LikesInNumbers = entity.LikesInNumbers,
//                DurationHours = entity.DurationHours,
//                Description = entity.Description,
//                Creator = entity.Creator != null ? CreatorFactory.Create(entity.Creator) : null,
//                Category = entity.Category != null ? CategoryFactory.Create(entity.Category) : null,
//                Details = entity.Details != null ? CourseDetailsFactory.Create(entity.Details) : null,
//                ProgramDetails = entity.ProgramDetails != null ? entity.ProgramDetails.Select(ProgramDetailsFactory.Create).ToList() : null,
//                LearningDetails = entity.LearningDetails != null ? entity.LearningDetails.Select(LearningDetailsFactory.Create).ToList() : null
//            };
//        }
//        catch { }
//        return null!;
//    }


//    public static IEnumerable<CourseDto> Create(List<CourseEntity> courseEntities)
//    {
//        List<CourseDto> courses = [];

//        try
//        {
//            foreach (var courseEntity in courseEntities)
//                courses.Add(Create(courseEntity));
//        }
//        catch { }
//        return courses;
//    }
//}
