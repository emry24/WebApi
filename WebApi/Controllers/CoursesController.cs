using AutoMapper;
using Infrastructure.Contexts;
using Infrastructure.Dtos;
using Infrastructure.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Linq.Expressions;
using WebApi.Dtos;
using WebApi.Filters;
using WebApi.Models;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
//[UseApiKey]
//[Authorize]

//public class CoursesController(AppDbContext context) : ControllerBase
public class CoursesController : ControllerBase
{
    //private readonly AppDbContext _context = context;
    private readonly CourseService _courseService;

    public CoursesController(CourseService courseService)
    {
        _courseService = courseService;
    }

    //[HttpGet]
    //public async Task<IActionResult> GetAll() => Ok(await _context.Courses.ToListAsync());

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var courses = await _courseService.GetAllCourses();
        return Ok(courses);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOne(int id)
    {
        //var course = await _context.Courses.FirstOrDefaultAsync(x => x.CourseId == id);
        //if (course != null)
        //{
        //    return Ok(course);
        //}

        //return NotFound();

        var courses = await _courseService.GetCourseById(x => x.CourseId == id);   

        return Ok(courses);
    }



    [HttpPost]
    public async Task<IActionResult> CreateCourse(CourseRegistrationDto courseRegistrationDto)
    {
        if (ModelState.IsValid)
        {
             var createdCourse = await _courseService.CreateCourse(courseRegistrationDto);
             return Ok(createdCourse);
        }

        return BadRequest();
    }


    //[HttpPut("{id}")]
    //public async Task<IActionResult> UpdateCourse(int id, CourseRegistrationDto updatedCourseDto)
    //{
    //    if (!ModelState.IsValid)
    //    {
    //        //var createdCourse = await _courseService.UpdateCourse();
    //        //return Ok(createdCourse);

    //        Expression<Func<CourseEntity, bool>> expression = c => c.CourseId == id;

    //        var updatedCourseEntity = _mapper.Map<CourseEntity>(updatedCourseDto);


    //        var updatedCourseDto = await _courseService.UpdateCourse(expression, updatedCourseEntity);

    //        return Ok(updatedCourseDto);
    //    }

    //    return BadRequest();
    //}

    //[HttpDelete]

}
