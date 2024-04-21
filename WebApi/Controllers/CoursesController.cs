using AutoMapper;
using Infrastructure.Contexts;
using Infrastructure.Dtos;
using Infrastructure.Entities;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;
using WebApi.Filters;


namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[UseApiKey]
[Authorize]

public class CoursesController : ControllerBase
{
    private readonly CourseService _courseService;
    private readonly CourseRepository _courseRepository;
    private readonly IMapper _mapper;
    private readonly AppDbContext _context;

    public CoursesController(CourseService courseService, CourseRepository courseRepository, IMapper mapper, AppDbContext context)
    {
        _courseService = courseService;
        _courseRepository = courseRepository;
        _mapper = mapper;
        _context = context;
    }


    #region Get All
    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> GetAllCourses(string category = "", string searchQuery = "", int pageNumber = 1, int pageSize = 6)
    {
        try
        {
            var query = _context.Courses.Include(i => i.Category).Include(i => i.Details).Include(i => i.Creator).AsQueryable();

            if (!string.IsNullOrWhiteSpace(category) && category.ToLower() != "all")
                query = query.Where(x => x.Category!.CategoryName == category);

            if (!string.IsNullOrEmpty(searchQuery))
                query = query.Where(x => x.Title.Contains(searchQuery) || x.Creator!.CreatorName.Contains(searchQuery));

            query = query.OrderByDescending(x => x.LastUpdated);

            var totalItems = await query.CountAsync();
            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            var coursesList = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            var courseDtos = _mapper.Map<IEnumerable<CourseDto>>(coursesList);

            var response = new CourseResultDto
            {
                Succeeded = true,
                TotalItems = totalItems,
                TotalPages = totalPages,
                Courses = courseDtos
            };

            return Ok(response);
        }
        catch (Exception ex)
        {
            Debug.WriteLine("ERROR :: " + ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    #endregion

    #region Get One

    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetOne(int id)
    {
        try
        {
            var courses = await _courseService.GetCourseById(x => x.CourseId == id);

            return Ok(courses);
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return StatusCode(StatusCodes.Status500InternalServerError);
    }
    #endregion

    #region Create

    //[Authorize]

    [HttpPost]
    public async Task<IActionResult> CreateCourse(CourseDto courseDto)
    {
        try
        {
            if (ModelState.IsValid)
            {
                var createdCourse = await _courseService.CreateCourse(courseDto);
                return Ok(createdCourse);
            }

            return BadRequest();
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return StatusCode(StatusCodes.Status500InternalServerError);
    }

    #endregion

    #region Update

    //[Authorize]

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
