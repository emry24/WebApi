using Infrastructure.Contexts;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories;

public class CourseDetailsRepository(AppDbContext context) : Repo<CourseDetailsEntity>(context)
{
    private readonly AppDbContext _context = context;

    public async Task<CourseDetailsEntity> GetByIdAsync(int id)
    {
        try
        {
            return await _context.Set<CourseDetailsEntity>().FirstOrDefaultAsync(x => x.CourseDetailsId == id);
        }
        catch (Exception ex)
        {
            Debug.WriteLine("ERROR :: " + ex.Message);
            return null!;
        }
    }

}
