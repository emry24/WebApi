using AutoMapper;
using Infrastructure.Dtos;
using Infrastructure.Entities;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;

namespace Infrastructure.Services;

public class CourseService(CourseRepository courseRepository, CreatorRepository creatorRepository, CategoryRepository categoryRepository, CourseDetailsRepository courseDetailsRepository, IMapper mapper)
{
    private readonly CourseRepository _courseRepository = courseRepository;
    private readonly CreatorRepository _creatorRepository = creatorRepository;
    private readonly CategoryRepository _categoryRepository = categoryRepository;
    private readonly CourseDetailsRepository _courseDetailsRepository = courseDetailsRepository;

    private readonly IMapper _mapper = mapper;

    #region Get All
    public async Task<IEnumerable<CourseEntity>> GetAllCourses()
    {
        return await _courseRepository.GetAllAsync();
    }

    #endregion

    #region Get One
    public async Task<CourseDto> GetCourseById(Expression<Func<CourseEntity, bool>> expression)
    {
        try
        {
            var courseEntity = await _courseRepository.GetAsync(expression);
            return _mapper.Map<CourseDto>(courseEntity);
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null!;
    }

    #endregion

    #region Create
    public async Task<CourseDto> CreateCourse(CourseRegistrationDto courseRegistrationDto)
    {
        try
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
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null!;

    }
    #endregion

    #region Update
    public async Task<CourseDto> UpdateCourse(Expression<Func<CourseEntity, bool>> expression, CourseEntity updatedEntity)
    {
        try
        {
            var existingCourse = await _courseRepository.GetAsync(expression);
            if (existingCourse != null)
            {
                existingCourse.Title = updatedEntity.Title;
                existingCourse.Ingress = updatedEntity.Ingress;
                existingCourse.IsBestseller = updatedEntity.IsBestseller;
                existingCourse.Reviews = updatedEntity.Reviews;
                existingCourse.RatingImage = updatedEntity.RatingImage;
                existingCourse.LikesInProcent = updatedEntity.LikesInProcent;
                existingCourse.LikesInNumbers = updatedEntity.LikesInNumbers;
                existingCourse.DurationHours = updatedEntity.DurationHours;
                existingCourse.Description = updatedEntity.Description;

                if (existingCourse.Details != null && updatedEntity.Details != null)
                {
                    existingCourse.Details!.NumberOfArticles = updatedEntity.Details!.NumberOfArticles;
                    existingCourse.Details.NumberOfResources = updatedEntity.Details.NumberOfResources;
                    existingCourse.Details.LifetimeAccess = updatedEntity.Details.LifetimeAccess;
                    existingCourse.Details.Certificate = updatedEntity.Details.Certificate;
                    existingCourse.Details.Price = updatedEntity.Details.Price;
                    existingCourse.Details.DiscountedPrice = updatedEntity.Details.DiscountedPrice;
                }

                if (updatedEntity.Category != null)
                {
                    var existingCategory = await _categoryRepository.GetAsync(x => x.CategoryName == updatedEntity.Category.CategoryName);

                    if (existingCategory != null)
                    {
                        existingCourse.Category = existingCategory;
                    }
                    else
                    {
                        var newCategory = new CategoryEntity { CategoryName = updatedEntity.Category.CategoryName };
                        existingCourse.Category = newCategory;
                    }
                }

                if (updatedEntity.Creator != null)
                {
                    var existingCreator = await _creatorRepository.GetAsync(x => x.CreatorName == updatedEntity.Creator.CreatorName);

                    if (existingCreator != null)
                    {
                        existingCourse.Creator = existingCreator;
                    }
                    else
                    {
                        var newCreator = new CreatorEntity
                        {
                            CreatorName = updatedEntity.Creator.CreatorName,
                            CreatorBio = updatedEntity.Creator.CreatorBio,
                            YoutubeSubscribers = updatedEntity.Creator.YoutubeSubscribers,
                            FacebookFollowers = updatedEntity.Creator.FacebookFollowers,
                            CreatorImage = updatedEntity.Creator.CreatorImage
                        };
                        existingCourse.Creator = newCreator;
                    }
                }

                if (updatedEntity.LearningDetails != null)
                {
                    foreach (var updatedLearningDetail in updatedEntity.LearningDetails)
                    {
                        var existingLearningDetail = existingCourse.LearningDetails!.FirstOrDefault(x => x.LearningsId == updatedLearningDetail.LearningsId);

                        if (existingLearningDetail != null)
                        {
                            existingLearningDetail.LearningsDescription = updatedLearningDetail.LearningsDescription;
                        }
                        else
                        {
                            existingCourse.LearningDetails!.Add(new LearningDetailsEntity
                            {
                                LearningsDescription = updatedLearningDetail.LearningsDescription
                            });
                        }
                    }
                }

                if (updatedEntity.ProgramDetails != null)
                {
                    foreach (var updatedProgramDetail in updatedEntity.ProgramDetails)
                    {
                        var existingProgramDetail = existingCourse.ProgramDetails!.FirstOrDefault(x => x.SectionId == updatedProgramDetail.SectionId);

                        if (existingProgramDetail != null)
                        {
                            existingProgramDetail.ProgramDetailsNumber = updatedProgramDetail.ProgramDetailsNumber;
                            existingProgramDetail.ProgramDetailsTitle = updatedProgramDetail.ProgramDetailsTitle;
                            existingProgramDetail.ProgramDetailsDescription = updatedProgramDetail.ProgramDetailsDescription;
                        }
                        else
                        {
                            existingCourse.ProgramDetails!.Add(new ProgramDetailsEntity
                            {
                                ProgramDetailsNumber = updatedProgramDetail.ProgramDetailsNumber,
                                ProgramDetailsTitle = updatedProgramDetail.ProgramDetailsTitle,
                                ProgramDetailsDescription = updatedProgramDetail.ProgramDetailsDescription
                            });
                        }
                    }
                }

                await _courseRepository.UpdateAsync(expression, existingCourse);
            };

            return _mapper.Map<CourseDto>(existingCourse);

        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null!;
    }
    #endregion
}

