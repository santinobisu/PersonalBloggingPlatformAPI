using PersonalBloggingPlatformAPI.Domain.Entities;

namespace PersonalBloggingPlatformAPI.Application.Interfaces.Articles
{
    public interface IArticleService
    {
        Task<Article> CreateArticle(string title, string bodyText, List<Tag> tags);
        Task<Article?> GetArticle(Guid id);
        Task<Article?> UpdateArticle(Guid id, string title, string bodyText, List<Tag> tags);
        Task<Article?> DeleteArticle(Guid id);
        Task<List<Article>> GetAll();
        Task<List<Article>> GetArticlesByTags(List<string> tagNames);
        Task<List<Article>> GetArticlesByPublishingDate(DateTime fromDate, DateTime toDate);
    }
}
