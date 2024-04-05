﻿using AutoMapper;
using Infrastructure.Configuration;
using Infrastructure.Dtos;
using Infrastructure.Entities;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Services;

public class CourseService(CourseRepository courseRepository, CreatorRepository creatorRepository, CategoryRepository categoryRepository, CourseDetailsRepository courseDetailsRepository, IMapper mapper)
{
    private readonly CourseRepository _courseRepository = courseRepository;
    private readonly CreatorRepository _creatorRepository = creatorRepository;
    private readonly CategoryRepository _categoryRepository = categoryRepository;
    private readonly CourseDetailsRepository _courseDetailsRepository = courseDetailsRepository;

    private readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<CourseEntity>> GetAllCourses()
    {
        return await _courseRepository.GetAllAsync();
    }

    public async Task<CourseDto> GetCourseById(Expression<Func<CourseEntity, bool>> expression)
    {
        var courseEntity = await _courseRepository.GetAsync(expression);
        return _mapper.Map<CourseDto>(courseEntity);       
    }

    public async Task<CourseDto> CreateCourse(CourseRegistrationDto courseRegistrationDto)
    {

        var existingCreator = await _creatorRepository.GetByNameAsync(courseRegistrationDto.CreatorName);
        if (existingCreator == null)
        {
            var creatorEntity = new CreatorEntity
            {
                CreatorName = courseRegistrationDto.CreatorName,
                CreatorBio = courseRegistrationDto.CreatorBio,
                CreatorImage = courseRegistrationDto.CreatorImage,
                YoutubeSubscribers = courseRegistrationDto.YoutubeSubscribers,
                FacebookFollowers = courseRegistrationDto.FacebookFollowers,
            };

            await _creatorRepository.CreateAsync(creatorEntity);
            existingCreator = creatorEntity;
        }

        var existingCategory = await _categoryRepository.GetByNameAsync(courseRegistrationDto.CategoryName);
        if (existingCategory == null)
        {
            var categoryEntity = new CategoryEntity
            {
                CategoryName = courseRegistrationDto.CategoryName,
            };

            await _categoryRepository.CreateAsync(categoryEntity);
            existingCategory = categoryEntity;
        }

        var courseDetailsEntity = new CourseDetailsEntity
        {
            NumberOfArticles = courseRegistrationDto.NumberOfArticles,
            NumberOfResources = courseRegistrationDto.NumberOfResources,
            LifetimeAccess = courseRegistrationDto.LifetimeAccess,
            Certificate = courseRegistrationDto.Certificate,

            Price = courseRegistrationDto.Price,
            DiscountedPrice = courseRegistrationDto.DiscountedPrice,
        };

        await _courseDetailsRepository.CreateAsync(courseDetailsEntity);

        var courseEntity = new CourseEntity
        {
            Title = courseRegistrationDto.Title,
            Ingress = courseRegistrationDto.Ingress,
            IsBestseller = courseRegistrationDto.IsBestseller,
            Reviews = courseRegistrationDto.Reviews,
            RatingImage = courseRegistrationDto.RatingImage,
            LikesInProcent = courseRegistrationDto.LikesInProcent,
            LikesInNumbers = courseRegistrationDto.LikesInNumbers,
            DurationHours = courseRegistrationDto.DurationHours,
            Description = courseRegistrationDto.Description,
            Category = existingCategory,
            Creator = existingCreator,
            Details = courseDetailsEntity,
        };

        var createdCourseEntity = await _courseRepository.CreateAsync(courseEntity);

        //var learningDetailsEntity = new LearningDetailsEntity
        //{
        //    LearningsDescription = form.LearningsDescription,
        //};
        //_context.LearningDetails.Add(learningDetailsEntity);


        //var programDetailsEntity = new ProgramDetailsEntity
        //{
        //    ProgramDetailsNumber = form.ProgramDetailsNumber,
        //    ProgramDetailsTitle = form.ProgramDetailsTitle,
        //    ProgramDetailsDescription = form.ProgramDetailsDescription,
        //};
        //_context.ProgramDetails.Add(programDetailsEntity);

        var createdCourseDto = new CourseDto
        {
            Title = createdCourseEntity.Title,
            Ingress = createdCourseEntity.Ingress,
            IsBestseller = createdCourseEntity.IsBestseller,
            Reviews = createdCourseEntity.Reviews,
            RatingImage = createdCourseEntity.RatingImage,
            LikesInProcent = createdCourseEntity.LikesInProcent,
            LikesInNumbers = createdCourseEntity.LikesInNumbers,
            DurationHours = createdCourseEntity.DurationHours,
            Description = createdCourseEntity.Description,
            Category = _mapper.Map<CategoryDto>(existingCategory),
            Creator = _mapper.Map<CreatorDto>(existingCreator),
            Details = _mapper.Map<CourseDetailsDto>(courseDetailsEntity)
        };

        return createdCourseDto;

    }


    public async Task<CourseDto> UpdateCourse(Expression<Func<CourseEntity, bool>> expression, CourseEntity updatedEntity)
    {
        var existingCourse = await _courseRepository.GetAsync(expression);
        if (existingCourse == null)
        {
            throw new Exception("Course not found.");
        }

        existingCourse.Title = updatedEntity.Title;
        existingCourse.Ingress = updatedEntity.Ingress;
        existingCourse.IsBestseller = updatedEntity.IsBestseller;
        existingCourse.Reviews = updatedEntity.Reviews;
        existingCourse.RatingImage = updatedEntity.RatingImage;
        existingCourse.LikesInProcent = updatedEntity.LikesInProcent;
        existingCourse.LikesInNumbers = updatedEntity.LikesInNumbers;
        existingCourse.DurationHours = updatedEntity.DurationHours;
        existingCourse.Description = updatedEntity.Description;

        await _courseRepository.UpdateAsync(expression, existingCourse);

        return _mapper.Map<CourseDto>(existingCourse);
    }

    //public async Task<CourseDto> DeleteCourse(Expression<Func<CourseEntity, bool>> expression)
    //{

    //}
}
