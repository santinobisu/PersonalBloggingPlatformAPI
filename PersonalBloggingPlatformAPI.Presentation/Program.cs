using Microsoft.EntityFrameworkCore;
using PersonalBloggingPlatformAPI.Application.Interfaces.Articles;
using PersonalBloggingPlatformAPI.Application.Services;
using PersonalBloggingPlatformAPI.Infrastructure.Data;
using PersonalBloggingPlatformAPI.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddDbContext<AppDbContext>(options =>
    {
        options.UseSqlite(builder.Configuration.GetConnectionString("personalBlogDb"), x => x.MigrationsAssembly("PersonalBloggingPlatformAPI.Presentation"));
    });
    builder.Services.AddScoped<IArticleRepository, ArticleRepository>();
    builder.Services.AddScoped<IArticleService, ArticleService>();
}

var app = builder.Build();
{
    app.MapControllers();
    app.Run();

}

