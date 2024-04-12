//using Infrastructure.Dtos;
//using Infrastructure.Entities;

//namespace Infrastructure.Factories;

//public class ProgramDetailsFactory
//{
//    public static ProgramDetailsDto Create(ProgramDetailsEntity entity)
//    {
//        try
//        {
//            return new ProgramDetailsDto
//            {
//                ProgramDetailsNumber = entity.ProgramDetailsNumber,
//                ProgramDetailsTitle = entity.ProgramDetailsTitle,
//                ProgramDetailsDescription = entity.ProgramDetailsDescription,
//            };
//        }
//        catch { }
//        return null!;
//    }

//    public static IEnumerable<ProgramDetailsDto> Create(List<ProgramDetailsEntity> entities)
//    {
//        List<ProgramDetailsDto> programDetails = [];

//        try
//        {
//            foreach (var entity in entities)
//                programDetails.Add(Create(entity));
//        }
//        catch { }
//        return programDetails;
//    }
//}
