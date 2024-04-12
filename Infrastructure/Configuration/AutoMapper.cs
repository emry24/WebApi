using AutoMapper;
using Infrastructure.Dtos;
using Infrastructure.Entities;


namespace Infrastructure.Configuration;

public class SettingsAutoMapper : Profile
{
    public SettingsAutoMapper()


    {
        CreateMap<CategoryEntity, CategoryDto>();
        CreateMap<CreatorEntity, CreatorDto>();
        CreateMap<CourseDetailsEntity, CourseDetailsDto>();
        CreateMap<ProgramDetailsEntity, ProgramDetailsDto>(); 
        CreateMap<LearningDetailsEntity, LearningDetailsDto>();
        
        CreateMap<CourseEntity, CourseDto>()
            
            // Include other mappings for properties that need to be updated
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Ingress, opt => opt.MapFrom(src => src.Ingress))
            .ForMember(dest => dest.IsBestseller, opt => opt.MapFrom(src => src.IsBestseller))

            .ForMember(dest => dest.Reviews, opt => opt.MapFrom(src => src.Reviews))
            .ForMember(dest => dest.RatingImage, opt => opt.MapFrom(src => src.RatingImage))
            .ForMember(dest => dest.LikesInProcent, opt => opt.MapFrom(src => src.LikesInProcent))
            .ForMember(dest => dest.LikesInNumbers, opt => opt.MapFrom(src => src.LikesInNumbers))
            .ForMember(dest => dest.DurationHours, opt => opt.MapFrom(src => src.DurationHours))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            // Map other properties similarly
            // Add mappings for nested objects if needed
            .ForMember(dest => dest.Details, opt => opt.MapFrom(src => src.Details))

            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))           
            .ForMember(dest => dest.Creator, opt => opt.MapFrom(src => src.Creator))

            .ForMember(dest => dest.LearningDetails, opt => opt.MapFrom(src => src.LearningDetails))
            .ForMember(dest => dest.ProgramDetails, opt => opt.MapFrom(src => src.ProgramDetails));



        CreateMap<CategoryDto, CategoryEntity>();
        CreateMap<CreatorDto, CreatorEntity>();
        CreateMap<CourseDetailsDto, CourseDetailsEntity>();
        CreateMap<ProgramDetailsDto, ProgramDetailsEntity>();
        CreateMap<LearningDetailsDto, LearningDetailsEntity>();

        CreateMap<CourseDto, CourseEntity>()
            // Include other mappings for properties that need to be updated
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Ingress, opt => opt.MapFrom(src => src.Ingress))
            .ForMember(dest => dest.IsBestseller, opt => opt.MapFrom(src => src.IsBestseller))

            .ForMember(dest => dest.Reviews, opt => opt.MapFrom(src => src.Reviews))
            .ForMember(dest => dest.RatingImage, opt => opt.MapFrom(src => src.RatingImage))
            .ForMember(dest => dest.LikesInProcent, opt => opt.MapFrom(src => src.LikesInProcent))
            .ForMember(dest => dest.LikesInNumbers, opt => opt.MapFrom(src => src.LikesInNumbers))
            .ForMember(dest => dest.DurationHours, opt => opt.MapFrom(src => src.DurationHours))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            // Map other properties similarly
            // Add mappings for nested objects if needed
            .ForMember(dest => dest.Details, opt => opt.MapFrom(src => src.Details))

            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
            .ForMember(dest => dest.Creator, opt => opt.MapFrom(src => src.Creator))

            .ForMember(dest => dest.LearningDetails, opt => opt.MapFrom(src => src.LearningDetails))
            .ForMember(dest => dest.ProgramDetails, opt => opt.MapFrom(src => src.ProgramDetails));
    }
}