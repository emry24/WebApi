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
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category));

    }
}