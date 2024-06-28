using PersonalBloggingPlatformAPI.Domain.Entities;

namespace PersonalBloggingPlatformAPI.Application.Interfaces.Articles
{
    public interface IArticleService
    {
        Task<Article> CreateArticle(Article newArticle);
        Task<Article> GetArticle(Guid id);
        Task<Article> UpdateArticle(Article article);
        Task<Article> DeleteArticle(Guid id);
    }
}
