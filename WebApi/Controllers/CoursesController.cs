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
        var course = await _context.Courses.FirstOrDefaultAsync( x => x.Id == id); 
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
            var courseEntity = new CourseEntity
            {
                Title = form.Title,
                Price = form.Price,
                DiscountPrice = form.DiscountPrice,
                Hours = form.Hours,
                IsBestseller = form.IsBestseller,
                LikesInNumbers = form.LikesInNumbers,
                LikesInProcent = form.LikesInProcent,
                Author = form.Author,
            };

            _context.Courses.Add(courseEntity);
            await _context.SaveChangesAsync();

            return Created("", (Course)courseEntity);
        }

        return BadRequest();
    }
}
