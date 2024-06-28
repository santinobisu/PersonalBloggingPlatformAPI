using Microsoft.EntityFrameworkCore;
using PersonalBloggingPlatformAPI.Domain.Entities;

namespace PersonalBloggingPlatformAPI.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Article> Articles { get; set; } = null!;
        public DbSet<Tag> Tags { get; set; } = null!;
    }
}
