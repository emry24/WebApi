using AutoMapper;
using Infrastructure.Dtos;
using Infrastructure.Entities;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Diagnostics;
using System.Linq.Expressions;
using WebApi.Filters;


namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
//[UseApiKey]
//[Authorize]

public class CoursesController : ControllerBase
{
    private readonly CourseService _courseService;
    private readonly CourseRepository _courseRepository;
    private readonly IMapper _mapper;

    public CoursesController(CourseService courseService, CourseRepository courseRepository, IMapper mapper)
    {
        _courseService = courseService;
        _courseRepository = courseRepository;
        _mapper = mapper;
    }


    #region Get All

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var courses = await _courseService.GetAllCourses();

            return Ok(courses);
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return StatusCode(StatusCodes.Status500InternalServerError);
    }
    #endregion

    #region Get One

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOne(int id)
    {
        try
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
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return StatusCode(StatusCodes.Status500InternalServerError);
    }
    #endregion

    #region Create

    [HttpPost]
    public async Task<IActionResult> CreateCourse(CourseRegistrationDto courseRegistrationDto)
    {
        try
        {
            if (ModelState.IsValid)
            {
                var createdCourse = await _courseService.CreateCourse(courseRegistrationDto);
                return Ok(createdCourse);
            }

            return BadRequest();
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return StatusCode(StatusCodes.Status500InternalServerError);
    }
    #endregion

    #region Update

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCourse(int id, CourseDto updatedCourseDto)
    {
        try
        {
            if (ModelState.IsValid)
            {
                var updatedCourseEntity = _mapper.Map<CourseEntity>(updatedCourseDto);
                var updatedCourse = await _courseService.UpdateCourse(x => x.CourseId == id, updatedCourseEntity);
                return Ok(updatedCourse);
            }

            return BadRequest();
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return StatusCode(StatusCodes.Status500InternalServerError);
    }
    #endregion

    #region Delete

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCourse(int id)
    {
        try
        {
            Expression<Func<CourseEntity, bool>> expression = x => x.CourseId == id;

            var isDeleted = await _courseRepository.DeleteAsync(expression);

            if (isDeleted)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return StatusCode(StatusCodes.Status500InternalServerError);
    }
    #endregion
}
