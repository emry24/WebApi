using Infrastructure.Contexts;
using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CourseDetailsRepository(AppDbContext context) : Repo<CourseDetailsEntity>(context)
    {
        private readonly AppDbContext _context = context;

    }
}
