//using Infrastructure.Dtos;
//using Infrastructure.Entities;

//namespace Infrastructure.Factories;

//public class LearningDetailsFactory
//{
//    public static LearningDetailsDto Create(LearningDetailsEntity entity)
//    {
//        try
//        {
//            return new LearningDetailsDto
//            {
//                LearningsDescription = entity.LearningsDescription,
//            };
//        }
//        catch { }
//        return null!;
//    }

//    public static IEnumerable<LearningDetailsDto> Create(List<LearningDetailsEntity> entities)
//    {
//        List<LearningDetailsDto> learningDetails = [];

//        try
//        {
//            foreach (var entity in entities)
//                learningDetails.Add(Create(entity));
//        }
//        catch { }
//        return learningDetails;
//    }
//}
