using Infrastructure.Contexts;
using Infrastructure.Factories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(AppDbContext context) : ControllerBase
    {
        private readonly AppDbContext _context = context;



        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _context.Categories.OrderBy(o => o.CategoryName).ToListAsync();
            return Ok(CategoryFactory.Create(categories));
        }
    }
}
