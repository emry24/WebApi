using AutoMapper;
using Infrastructure.Configuration;
using Infrastructure.Dtos;
using Infrastructure.Entities;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Linq.Expressions;

namespace Infrastructure.Services;

public class CourseService
{
    private readonly CourseRepository _courseRepository;

    private readonly IMapper _mapper;

    public CourseService(CourseRepository courseRepository, IMapper mapper)
    {
        _courseRepository = courseRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CourseEntity>> GetAllCourses()
    {
        return await _courseRepository.GetAllAsync();
    }

    public async Task<CourseDto> GetCourseById(Expression<Func<CourseEntity, bool>> expression)
    {
        var courseEntity = await _courseRepository.GetAsync(expression);
        return _mapper.Map<CourseDto>(courseEntity);       
    }
}
