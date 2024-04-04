using AutoMapper;
using Infrastructure.Dtos;
using Infrastructure.Entities;


namespace Infrastructure.Configuration;

public class SettingsAutoMapper : Profile
{
    public SettingsAutoMapper()
    {
        CreateMap<CourseEntity, CourseDto>();

        //CreateMap<CourseDto, CourseEntity>();
       
    }
}