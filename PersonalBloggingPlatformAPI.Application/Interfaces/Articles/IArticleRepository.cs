using PersonalBloggingPlatformAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBloggingPlatformAPI.Application.Interfaces.Articles
{
    public interface IArticleRepository
    {
        Task<Article> CreateArticle(Article newArticle);
        Task<Article?> GetArticle(Guid id);
        Task<Article?> UpdateArticle(Guid id, Article article);
        Task<Article?> DeleteArticle(Guid id);
        Task<List<Article>> GetAll();
        Task<List<Article>> GetArticlesByTags(List<string> tagNames);
        Task<List<Article>> GetArticlesByPublishingDate(DateTime fromDate, DateTime toDate);
    }
}
