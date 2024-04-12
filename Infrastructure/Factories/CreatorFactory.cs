//using Infrastructure.Dtos;
//using Infrastructure.Entities;

//namespace Infrastructure.Factories;

//public class CreatorFactory
//{
//    public static CreatorDto Create(CreatorEntity entity)
//    {
//        try
//        {
//            return new CreatorDto
//            {
//                CreatorId = entity.CreatorId,
//                CreatorName = entity.CreatorName,
//                CreatorBio = entity.CreatorBio,
//                YoutubeSubscribers = entity.YoutubeSubscribers,
//                FacebookFollowers = entity.FacebookFollowers,
//                CreatorImage = entity.CreatorImage
//            };
//        }
//        catch { }
//        return null!;
//    }

//    public static IEnumerable<CreatorDto> Create(List<CreatorEntity> creatorEntities)
//    {
//        List<CreatorDto> creators = [];

//        try
//        {
//            foreach (var creatorEntity in creatorEntities)
//                creators.Add(Create(creatorEntity));
//        }
//        catch { }
//        return creators;
//    }
//}
