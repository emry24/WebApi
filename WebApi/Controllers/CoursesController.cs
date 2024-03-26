﻿using Infrastructure.Contexts;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Dtos;
using WebApi.Models;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CoursesController(AppDbContext context) : ControllerBase
{
    private readonly AppDbContext _context = context;

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _context.Courses.ToListAsync());



    [HttpGet("{id}")]
    public async Task<IActionResult> GetOne(int id)
    {
        var course = await _context.Courses.FirstOrDefaultAsync(x => x.CourseId == id);
        if (course != null)
        {
            return Ok(course);
        }

        return NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> CreateOne(CourseRegistrationForm form)
    {
        if (ModelState.IsValid)
        {
            var existingCategory = await _context.Categories.FirstOrDefaultAsync(c => c.CategoryName == form.CategoryName);
            if (existingCategory == null)
            {
                var categoryEntity = new CategoryEntity
                {
                    CategoryName = form.CategoryName,
                };

                _context.Categories.Add(existingCategory!);
            }

            var existingCreator = await _context.Creators.FirstOrDefaultAsync(c => c.CreatorName == form.CreatorName);
            if (existingCreator == null)
            {
                var creatorEntity = new CreatorEntity
                {
                    CreatorName = form.CreatorName,
                    CreatorBio = form.CreatorBio,
                    YoutubeSubscribers = form.YoutubeSubscribers,
                    FacebookFollowers = form.FacebookFollowers,
                    CreatorImage = form.CreatorImage,
                };

                _context.Creators.Add(existingCreator!);
            }

            var courseDetailsEntity = new CourseDetailsEntity
            {
                NumberOfArticles = form.NumberOfArticles,
                NumberOfResources = form.NumberOfResources,
                LifetimeAccess = form.LifetimeAccess,
                Certificate = form.Certificate,
                Price = form.Price,
                DiscountedPrice = form.DiscountedPrice,
            };

            _context.CourseDetails.Add(courseDetailsEntity);

            var courseEntity = new CourseEntity
            {
                Title = form.Title,
                Ingress = form.Ingress,
                IsBestseller = form.IsBestseller,
                Reviews = form.Reviews,
                RatingImage = form.RatingImage,
                LikesInProcent = form.LikesInProcent,
                LikesInNumbers = form.LikesInNumbers,
                DurationHours = form.DurationHours,
                Description = form.Description,
                Category = existingCategory,
                Creator = existingCreator,
                Details = courseDetailsEntity,
            };

            _context.Courses.Add(courseEntity);



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

            await _context.SaveChangesAsync();

            return Created("", (Course)courseEntity);
        }

        return BadRequest();
    }
}
