using Infrastructure;
using Infrastructure.Configuration;
using Infrastructure.Repositories;
using Infrastructure.Services;
using System.Text.Json.Serialization;
using WebApi.Configurations;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers().AddJsonOptions(x =>
{
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    x.JsonSerializerOptions.WriteIndented = true;
});

builder.Services.AddScoped<CategoryRepository>();
builder.Services.AddScoped<CreatorRepository>();
builder.Services.AddScoped<CourseDetailsRepository>();
builder.Services.AddScoped<CourseRepository>();
builder.Services.AddScoped<CourseService>();

builder.Services.AddAutoMapper(typeof(SettingsAutoMapper));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));
builder.Services.RegisterDbContexts(builder.Configuration);
builder.Services.RegisterSwagger();
builder.Services.RegisterJwt(builder.Configuration);
var app = builder.Build();

app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.UseSwagger();
//app.UseSwaggerUI();
app.UseSwaggerUI(x => x.SwaggerEndpoint("/swagger/v1/swagger.json", "Silicon Web Api v1"));
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
