using Microsoft.EntityFrameworkCore;
using PersonalBloggingPlatformAPI.Application.Interfaces.Articles;
using PersonalBloggingPlatformAPI.Application.Interfaces.Tags;
using PersonalBloggingPlatformAPI.Application.Services;
using PersonalBloggingPlatformAPI.Infrastructure.Data;
using PersonalBloggingPlatformAPI.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args); // Services and Middlewares
{
    builder.Services.AddControllers();

    builder.Services.AddDbContext<AppDbContext>(options =>
    {
        options.UseSqlite(builder.Configuration.GetConnectionString("personalBlogDb"), x => x.MigrationsAssembly("PersonalBloggingPlatformAPI.Presentation"));
    });

    builder.Services.AddScoped<IArticleRepository, ArticleRepository>();
    builder.Services.AddScoped<IArticleService, ArticleService>();

    builder.Services.AddScoped<ITagRepository, TagRepository>();
}

var app = builder.Build(); // HTTP PIPELINE
{
    app.MapControllers();
    app.Run();

}

