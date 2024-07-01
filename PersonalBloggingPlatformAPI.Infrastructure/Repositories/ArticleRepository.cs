using PersonalBloggingPlatformAPI.Application.Interfaces.Articles;
using PersonalBloggingPlatformAPI.Domain.Entities;
using PersonalBloggingPlatformAPI.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBloggingPlatformAPI.Infrastructure.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly AppDbContext _appDbContext;
        public ArticleRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<Article> CreateArticle(Article newArticle)
        {
            await _appDbContext.AddAsync(newArticle);
            await _appDbContext.SaveChangesAsync();

            return newArticle;
        }

        public async Task<Article> DeleteArticle(Guid id)
        {
            var articleToDelete = await _appDbContext.Articles.FindAsync(id);

            if (articleToDelete is null)
            {
                return null;
            }

            _appDbContext.Articles.Remove(articleToDelete);

            await _appDbContext.SaveChangesAsync();

            return articleToDelete;
        }

        public async Task<Article> GetArticle(Guid id)
        {
            var result = await _appDbContext.Articles.FindAsync(id);

            return result;
        }
        public async Task<Article> UpdateArticle(Guid id, Article article)
        {
            var articleToUpdate = await _appDbContext.Articles.FindAsync(id);

            if (articleToUpdate is null)
            {
                return null;
            }

            articleToUpdate.Title = article.Title;
            articleToUpdate.BodyText = article.BodyText;

            await _appDbContext.SaveChangesAsync();

            return article;
        }
    }
}
