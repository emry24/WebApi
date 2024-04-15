using AutoMapper;
using Infrastructure.Dtos;
using WebApp.Models;

namespace WebApp.Configuration;

public class SettingsAutoMapper : Profile
{
    public SettingsAutoMapper()
    {

        //glöm inte att installera och config in startup

        //CreateMap<CategoryDto, CategoryModel>();
        //CreateMap<CreatorDto, CreatorModel>();
        //CreateMap<CourseDetailsDto, CourseDetailsModel>();
        //CreateMap<CourseDto, CourseModel>()
        //    .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category));

        CreateMap<CategoryDto, CategoryModel>();
        CreateMap<CreatorDto, CreatorModel>();
        CreateMap<CourseDetailsDto, CourseDetailsModel>();
        CreateMap<ProgramDetailsDto, ProgramDetailsModel>();
        CreateMap<LearningDetailsDto, LearningDetailsModel>();
        CreateMap<CourseDto, CourseModel>()
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
            .ForMember(dest => dest.ProgramDetails, opt => opt.MapFrom(src => src.ProgramDetails))
            .ForMember(dest => dest.LearningDetails, opt => opt.MapFrom(src => src.LearningDetails));

        CreateMap<CategoryModel, CategoryDto>();
        CreateMap<CreatorModel, CreatorDto>();
        CreateMap<CourseDetailsModel, CourseDetailsDto>();
        CreateMap<ProgramDetailsModel, ProgramDetailsDto>();
        CreateMap<LearningDetailsModel, LearningDetailsDto>();
        CreateMap<CourseModel, CourseDto>()
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
            .ForMember(dest => dest.ProgramDetails, opt => opt.MapFrom(src => src.ProgramDetails))
            .ForMember(dest => dest.LearningDetails, opt => opt.MapFrom(src => src.LearningDetails));


    }
}
