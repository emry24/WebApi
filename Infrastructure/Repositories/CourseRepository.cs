using Infrastructure.Contexts;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{

    public class CourseRepository(AppDbContext context) : Repo<CourseEntity>(context)
    {
        private readonly AppDbContext _context = context;

        public override async Task<CourseEntity> GetAsync(Expression<Func<CourseEntity, bool>> expression)
        {
            try
            {
                var entity = await _context.Courses
                .Include(x => x.Category)
                .Include(x => x.Creator)
                .Include(x => x.Details)
                .Include(x => x.LearningDetails)
                .Include(x => x.ProgramDetails)
                .FirstOrDefaultAsync(expression);
                if (entity != null)
                {
                    return entity;
                }
            }
            catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
            return null!;
        }

        //public override async Task<IEnumerable<CourseEntity>> GetAllAsync()
        //{
        //    try
        //    {
        //        var entities = await _context.Courses
        //        .Include(x => x.Category).AsQueryable()
        //        .Include(x => x.Creator)
        //        .Include(x => x.Details)
        //        .OrderByDescending(x => x.LastUpdated)
        //        .ToListAsync();
        //        if (entities != null)
        //        {
        //            return entities;
        //        }
        //    }
        //    catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        //    return null!;
        //}
    }
}
