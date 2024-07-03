using Microsoft.EntityFrameworkCore;
using PersonalBloggingPlatformAPI.Application.Interfaces.Articles;
using PersonalBloggingPlatformAPI.Application.Interfaces.Tags;
using PersonalBloggingPlatformAPI.Application.Services;
using PersonalBloggingPlatformAPI.Infrastructure.Data;
using PersonalBloggingPlatformAPI.Infrastructure.Repositories;
using PersonalBloggingPlatformAPI.Presentation.Middlewares;

var builder = WebApplication.CreateBuilder(args); // Services
{
    builder.Services.AddControllers();

    builder.Services.AddDbContext<AppDbContext>(options =>
    {
        options.UseSqlite(builder.Configuration.GetConnectionString("personalBlogDb"), x => x.MigrationsAssembly("PersonalBloggingPlatformAPI.Presentation"));
    });

    builder.Services.AddScoped<IArticleRepository, ArticleRepository>();
    builder.Services.AddScoped<IArticleService, ArticleService>();

    builder.Services.AddScoped<ITagRepository, TagRepository>();
    builder.Services.AddScoped<ITagService, TagService>();
}


var app = builder.Build(); // HTTP Pipeline and Middleware
{
    app.UseMiddleware<JsonExceptionHandlingMiddleware>();
    app.MapControllers();
    app.Run();

}

