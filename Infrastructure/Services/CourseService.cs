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

        //var coursesDto = new CoursesDto
        //{
        //    CourseDto = new CourseDto
        //    {
        //        Title = courseEntity.Title,
        //        Ingress = courseEntity.Ingress,
        //        IsBestseller = courseEntity.IsBestseller,
        //        Reviews = courseEntity.Reviews,
        //        RatingImage = courseEntity.RatingImage,
        //        LikesInProcent = courseEntity.LikesInProcent,
        //        LikesInNumbers = courseEntity.LikesInNumbers,
        //        DurationHours = courseEntity.DurationHours,
        //        Description = courseEntity.Description,
        //    },
        //    CategoryDto = new CategoryDto
        //    {
        //        CategoryName = courseEntity.Category.CategoryName,
        //    },
        //    CourseDetailsDto = new CourseDetailsDto
        //    {
        //        Price = courseEntity.Details.Price,
        //        DiscountedPrice = courseEntity.Details.DiscountedPrice,
        //        NumberOfArticles = courseEntity.Details.NumberOfArticles,
        //        NumberOfResources = courseEntity.Details.NumberOfResources,
        //        LifetimeAccess = courseEntity.Details.LifetimeAccess,
        //        Certificate = courseEntity.Details.Certificate,
        //    },
        //    CreatorDto = new CreatorDto
        //    {
        //        CreatorName = courseEntity.Creator.CreatorName,
        //        CreatorBio = courseEntity.Creator.CreatorBio,
        //        YoutubeSubscribers = courseEntity.Creator.YoutubeSubscribers,
        //        FacebookFollowers = courseEntity.Creator.FacebookFollowers,
        //        CreatorImage = courseEntity.Creator.CreatorImage
        //    },
            
        //};

       
    }


}
