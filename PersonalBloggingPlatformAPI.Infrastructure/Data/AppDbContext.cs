using Microsoft.EntityFrameworkCore;
using PersonalBloggingPlatformAPI.Domain.Entities;

namespace PersonalBloggingPlatformAPI.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>()
                .HasMany(x => x.Tags)
                .WithMany(y => y.Articles)
                .UsingEntity(j => j.ToTable("ArticleTag"));

            modelBuilder.Entity<Tag>()
                .HasData(
                new Tag { TagId = 1, Name = "Technology"},
                new Tag { TagId = 2, Name = "Science" },
                new Tag { TagId = 3, Name = "Tutorials" },
                new Tag { TagId = 4, Name = "Trips" },
                new Tag { TagId = 5, Name = "Videogames" },
                new Tag { TagId = 6, Name = "Education" });
        }

        public DbSet<Article> Articles { get; set; } = null!;
        public DbSet<Tag> Tags { get; set; } = null!;
    }
}
