﻿using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Configurations;

public static class DbContextConfiguration
{
    public static void RegisterDbContexts(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(x => x.UseSqlServer(configuration.GetConnectionString("SqlServer")));
    }
}
