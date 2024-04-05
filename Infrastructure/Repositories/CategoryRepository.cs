using Infrastructure.Contexts;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Infrastructure.Repositories;

public class CategoryRepository(AppDbContext context) : Repo<CategoryEntity>(context)
{
    private readonly AppDbContext _context = context;

    public async Task<CategoryEntity> GetByNameAsync(string categoryName)
    {
        try
        {
            return await _context.Set<CategoryEntity>().FirstOrDefaultAsync(x => x.CategoryName == categoryName);
        }
        catch (Exception ex)
        {
            Debug.WriteLine("ERROR :: " + ex.Message);
            return null;
        }
    }
}


