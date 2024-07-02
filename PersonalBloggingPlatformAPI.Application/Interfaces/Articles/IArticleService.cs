using PersonalBloggingPlatformAPI.Domain.Entities;

namespace PersonalBloggingPlatformAPI.Application.Interfaces.Articles
{
    public interface IArticleService
    {
        Task<Article> CreateArticle(string title, string bodyText, List<int?> tagsId);
        Task<Article> GetArticle(Guid id);
        Task<Article> UpdateArticle(Guid id, string title, string bodyText, List<int?> tagsId);
        Task<Article> DeleteArticle(Guid id);
    }
}
