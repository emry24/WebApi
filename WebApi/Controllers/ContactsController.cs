using Infrastructure.Contexts;
using Infrastructure.Dtos;
using Microsoft.AspNetCore.Mvc;
using WebApi.Filters;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[UseApiKey]
public class ContactsController(AppDbContext context) : ControllerBase
{
    private readonly AppDbContext _context = context;

    #region CREATE

    [HttpPost]
    public async Task<IActionResult> Create(ContactDto dto)
    {
        if (ModelState.IsValid)
        {
                try
                {
                    _context.Contacts.Add(dto);
                    await _context.SaveChangesAsync();

                    return Created("", null);
                }
                catch
                {
                    return Problem("Unable to create contact request");
                }
        }
        return BadRequest();
    }

    #endregion
}
