using Infrastructure.Contexts;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Infrastructure.Repositories;

public class CreatorRepository(AppDbContext context) : Repo<CreatorEntity>(context)
{
    private readonly AppDbContext _context = context;


    public async Task<CreatorEntity> GetByNameAsync(string creatorName)
    {
        try
        {
            return await _context.Set<CreatorEntity>().FirstOrDefaultAsync(x => x.CreatorName == creatorName);
        }
        catch (Exception ex)
        {
            Debug.WriteLine("ERROR :: " + ex.Message);
            return null;
        }
    }
}
